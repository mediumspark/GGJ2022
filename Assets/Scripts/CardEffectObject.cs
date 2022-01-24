using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardEffectObject : MonoBehaviour
{
    [SerializeField]
    protected Card CardBase;
    public Card SetCardBase { set => CardBase = value; }
    public int MindMod, BodyMod; 



    [SerializeField]
    TextMeshProUGUI Description, Title;

    [SerializeField]
    Image Secondary; 

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

    public void SetCard()
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
}

public class ItemCardEffect : CardEffectObject
{   
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
