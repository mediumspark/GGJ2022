using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;


public enum MovementDirection { Up, Right, Left, Down, nil }

public class CardEffectObject : MonoBehaviour
{
    [SerializeField]
    protected Card CardBase;
    public Card SetCardBase { set => CardBase = value; }
    public int MindMod, BodyMod; 

    MovementDirection MD = MovementDirection.nil; 

    [SerializeField]
    protected TextMeshProUGUI Description, Title;

    [SerializeField]
    protected Image Secondary; 

    /// <summary>
    /// Used as a modifier in the Items and used to create paths in the Event Cards
    /// </summary>
    public virtual void BodyTrigger()
    {
    }

    /// <summary>
    /// Used as a modifier in the Items and used to create paths in the Events
    /// </summary>
    public virtual void MindTrigger()
    {

    }

    private void Update()
    {
        switch (MD)
        {
            case MovementDirection.Down:
                transform.Translate(Vector3.down * 200);
                break;
            case MovementDirection.Up:
                transform.Translate(Vector3.up * 200);
                break;
            case MovementDirection.Left:
                transform.Translate(Vector3.left * 200);
                break;
            case MovementDirection.Right:
                transform.Translate(Vector3.right * 200);
                break;
            default: break; 
        }
    }

    public virtual void SetCard()
    {
        Description = FindObjectOfType<UIManager>().DescisionResult;
        Title = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        Secondary = transform.GetChild(0).GetChild(1).GetComponent<Image>();

        Description.text = CardBase.EffectDesc; 
        Title.text = CardBase.EffectName;
        Secondary.sprite = CardBase.ForgroundSprite;
        MindMod = CardBase.MindMod; 
        BodyMod = CardBase.BodyMod;
    }

    public void MoveCard(MovementDirection MD, IEnumerator<WaitForSeconds> nextCard)
    {
        StartCoroutine(nextCard);
        this.MD = MD; 
    }
}

public class ItemCardEffect : CardEffectObject
{
    public override void SetCard()
    {
        Description = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        Title = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        Secondary = transform.GetChild(0).GetChild(2).GetComponent<Image>();

        Description.text = CardBase.EffectDesc;
        Title.text = CardBase.EffectName;
        Secondary.sprite = CardBase.ForgroundSprite;
        MindMod = CardBase.MindMod;
        BodyMod = CardBase.BodyMod;
    }

    public virtual void OnUseFromDeck()
    {
        if(GameManager.instance.CurrentPhase == Phases.Bag)
            PlayerStats.instance.HoldDeck.Add(CardBase);
        else 
        {
            //Use cards to minimize the cost of certain cards

        }

    }
}

public class EventCardEffect : CardEffectObject
{

}

public class TalkativeSpiderlingEffect : EventCardEffect { }
public class TrapWallEffect : EventCardEffect { }
public class BedofFlamesEffect : EventCardEffect { }
public class DoorFromThePitEffect : EventCardEffect { }
public class TheDoorAtTheEndOfThePit_1 : EventCardEffect { }
public class TheDoorAtTheEndOfThePit_2 : EventCardEffect { }
public class TheMawEffect : EventCardEffect { }
public class Room_1Effect : EventCardEffect { }
public class Room_5Effect : EventCardEffect { }
public class Floor_2Effect : EventCardEffect { }
public class MawServent_1Effect : EventCardEffect { }
public class MawServent_2Effect : EventCardEffect { }
public class MawServent_3Effect : EventCardEffect { }
public class SideOfInnEffect : EventCardEffect { }
public class BackOfInnEffect : EventCardEffect { }
public class TheCorruptionEffect : EventCardEffect { }
public class BeingFromTheMawEffect : EventCardEffect { }
public class DesireOfTheMawEffect : EventCardEffect { }
public class TemptationOfTheMawEffect : EventCardEffect { }
public class LoveOfTheMawEffect : EventCardEffect { }
public class BowEffect : ItemCardEffect { }
public class SlingEffect : ItemCardEffect { }
public class LanternEffect : ItemCardEffect { }
public class BookEffect : ItemCardEffect { }
public class LanceEffect : ItemCardEffect { }
public class GardenSwordEffect : ItemCardEffect { }
public class DawkinsRazorEffect : ItemCardEffect { }
public class MawBladeEffect : ItemCardEffect { }
public class RatsBaneEffect : ItemCardEffect { }
public class CibophileJawsEffect : ItemCardEffect { }