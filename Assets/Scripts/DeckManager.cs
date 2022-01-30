using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
#endif

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;
    DeckGenerator DeckGen;
    public AdventureDeckScriptableObject ADeckSO;

    [SerializeField]
    GameObject CurrentCard;

    public CardEffectObject CurrentCardEffect => CurrentCard.GetComponent<CardEffectObject>();

    [SerializeField]
    List<Card> ItemDeck;

    public List<Card> AdventureDeck;

    private void Awake()
    {
        instance = this;
        DeckGen = new DeckGenerator();
        FillDeck();
        CreateCard(ItemDeck[0]);
    }

    public void CreateCard(Card C)
    {
        GameObject go = Instantiate(C.CardEffectPrefab, gameObject.transform);

        switch (C.name)
        {
            #region Items
            case "Sword":
                go.AddComponent<SwordEffect>();
                break;

            case "Shield":
                go.AddComponent<ShieldEffect>();
                break;

            case "Club":
                go.AddComponent<ClubEffect>();
                break;

            case "Bow":
                go.AddComponent<BowEffect>();
                break;
            case "Sling":
                go.AddComponent<SlingEffect>();
                break;
            case "Lantern":
                go.AddComponent<LanternEffect>();
                break;
            case "Book":
                go.AddComponent<BookEffect>();
                break;
            case "Lance":
                go.AddComponent<LanceEffect>();
                break;
            case "GardenSword":
                go.AddComponent<GardenSwordEffect>();
                break;
            case "DawkinsRazor":
                go.AddComponent<DawkinsRazorEffect>();
                break;
            case "MawBlade":
                go.AddComponent<MawBladeEffect>();
                break;
            case "RatsBane":
                go.AddComponent<RatsBaneEffect>();
                break;
            case "CibophileJaws":
                go.AddComponent<CibophileJawsEffect>();
                break; 
            #endregion
            #region Events
            case "Garden":
                go.AddComponent<GardenEffect>();
                break;

            case "EndlessMischief":
                go.AddComponent<EndlessMischiefEffect>();
                break;

            case "GardenEnd":
                go.AddComponent<GardenEndEffect>();
                break;

            case "GardenIntro":
                go.AddComponent<GardenIntroEffect>();  
                break;

            case "TheGreatPit1":
                go.AddComponent<TheGreatPitEffect_1>();
                break;
            case "TheGreatPit2":
                go.AddComponent<TheGreatPitEffect_2>();
                break;
            case "TokenNightmare":
                go.AddComponent<TokenNightmareEffect>();
                break;
            case "TheBumpInTheDarkness":
                go.AddComponent<TheBumpInTheDarkness>();
                break;
            case "TorchGoblin":
                go.AddComponent<TorchGoblinEffect>();
                break;
            case "TrapDoor":
                go.AddComponent<TrapDoorEffect>();
                break;
            case "BedOfFlames":
                go.AddComponent<BedofFlamesEffect>();
                break;
            case "LadderFromPit":
                go.AddComponent<LadderFromThePitEffect>();
                break;
            case "DoorFromThePit":
                go.AddComponent<DoorFromThePitEffect>();
                break;
            #endregion
            default:
                go.AddComponent<UnderConstructionEffect>(); 
                break;
        }

        go.GetComponent<CardEffectObject>().SetCardBase = C;
        CurrentCard = go;

        CurrentCard.GetComponent<CardEffectObject>().SetCard();
    }

    public void FillDeck()
    {
        if (GameManager.instance.CurrentPhase == Phases.Bag)
        {
            for (int i = 0; i < 5; i++)
                ItemDeck.Add(DeckGen.ItemGeneration());

        }
        else if (GameManager.instance.CurrentPhase == Phases.Adventure)
        {
            AdventureDeck.AddRange(ADeckSO.AdventureCards);
        }
    }

    public IEnumerator<WaitForSeconds> NextCard()
    {
        yield return new WaitForSeconds(0.5f);

        if (GameManager.instance.CurrentPhase == Phases.Bag)
        {
            ItemDeck.RemoveAt(0);
            Destroy(CurrentCard);
            if (ItemDeck.Count > 0)
            {
                CreateCard(ItemDeck[0]);
            }
            else
            {
                GameManager.instance.CurrentPhase = Phases.Adventure;
                FillDeck();
                StartCoroutine(NextCard());
            }
        }
        else
        {
            AdventureDeck.RemoveAt(0);
            Destroy(CurrentCard);
            if (AdventureDeck.Count > 0)
            {
                CreateCard(AdventureDeck[0]);
            }
            else
            {
                ItemDeck.Clear();

                GameManager.instance.CurrentPhase = Phases.Bag;
                FindObjectOfType<UIManager>().DescisionResult.text = PlayerStats.instance.EndAdventure();
                FillDeck();
                StartCoroutine(NextCard());
            }
        }
    }

    /// <summary>
    /// Meant to be used for the "End of Run Cards" and for the game over to signified the player has tried this x amount of times
    /// </summary>
    public void SubmitRun()
    {
        if (PlayerStats.instance.Body <= 0 || PlayerStats.instance.Mind <= 0) { }
    }

    public void AddToDeck()
    {
        if (CurrentCard.TryGetComponent<ItemCardEffect>(out ItemCardEffect ItemCard))
        {
            if (PlayerStats.instance.Body <= 0 || PlayerStats.instance.Mind <= 0)
            {
                FindObjectOfType<UIManager>().DescisionResult.text = "You are too weak to add this to your deck";
            }
            else
            {
                FindObjectOfType<UIManager>().DescisionResult.text = "";
                ItemCard.OnUseFromDeck();
                CurrentCard.GetComponent<CardEffectObject>().MoveCard(MovementDirection.Down, NextCard());
            }
        }
        else
        {
            PlayerStats.instance.PlayCard();
        }
    }

    public void TrashorNegate()
    {
        if (PlayerStats.instance.Body <= 0 || PlayerStats.instance.Mind <= 0)
        {
            FindObjectOfType<UIManager>().DescisionResult.text = "You are too weak to add this to your deck";
            if (CurrentCard.TryGetComponent<ItemCardEffect>(out ItemCardEffect ItemCard))
                CurrentCard.GetComponent<CardEffectObject>().MoveCard(MovementDirection.Up, NextCard());
        }
    } 

    /* Mind and Body Commits for Events will need to show results of your event choices and then lead*/

    public void CommitToMind()
    {
        CurrentCard.GetComponent<CardEffectObject>().MindTrigger();
        CurrentCard.GetComponent<CardEffectObject>().MoveCard(MovementDirection.Left, NextCard()); 
    }
    public void CommitToBody()
    {
        CurrentCard.GetComponent<CardEffectObject>().BodyTrigger();
        CurrentCard.GetComponent<CardEffectObject>().MoveCard(MovementDirection.Right, NextCard());
    }
}
