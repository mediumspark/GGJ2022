using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
#endif

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;
    DeckGenerator DeckGen;
    public Deck ADeckSO; 

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
            case "Sword":
                go.AddComponent<SwordEffect>(); 
                break;

            case "Shield":
                go.AddComponent<ShieldEffect>(); 
                break;

            case "Garden":
                go.AddComponent<GardenEffect>(); 
                break;

            case "AngryRat":
                go.AddComponent<AngryRat>(); 
                break; 
                
            case "GardenEnd":
                go.AddComponent<GardenEndEffect>(); 
                break;

            case "Club":
                go.AddComponent<ClubEffect>();
                break; 

            default:
                Debug.LogError("Not a CardName");
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
            if (ADeckSO.Runs == 0)
                for (int i = 0; i < 5; i++)
                    ItemDeck.Add(DeckGen.ItemGeneration());
            else
                for (int i = 0; i < 3; i++)
                    ItemDeck.Add(DeckGen.ItemGeneration()); 

        }
        else if (GameManager.instance.CurrentPhase == Phases.Adventure)
        {
            AdventureDeck.AddRange(ADeckSO.AdventureCards); 
        }
    }

    public void NextCard()
    {
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
                NextCard();
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
                NextCard();
            }
        }
    }
    
    /// <summary>
    /// Meant to be used for the "End of Run Cards" and for the game over to signified the player has tried this x amount of times
    /// </summary>
    public void SubmitRun()
    {
        ADeckSO.Runs++;
        if (PlayerStats.instance.Body <= 0 || PlayerStats.instance.Mind <= 0)
            ADeckSO.Deaths++; 
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
                ItemCard.OnUseFromDeck();
                NextCard();
            }
        }
        else
        {
            PlayerStats.instance.PlayCard(); 
        }
    }

    public void TrashorNegate()
    {
        if (CurrentCard.TryGetComponent<ItemCardEffect>(out ItemCardEffect ItemCard))
            NextCard();
    }

    
    /* Mind and Body Commits for Events will need to show results of your event choices and then lead
     */

    public void CommitToMind()
    {
        CurrentCard.GetComponent<CardEffectObject>().MindTrigger();
        NextCard();
    }
    public void CommitToBody()
    {
        CurrentCard.GetComponent<CardEffectObject>().BodyTrigger();
        NextCard();
    }
}
