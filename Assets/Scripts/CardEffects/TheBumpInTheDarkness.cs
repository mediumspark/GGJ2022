using UnityEngine;

public class TheBumpInTheDarkness : EventCardEffect 
{
    private void Awake()
    {
        FindObjectOfType<UIManager>().DescisionResult.text =  "As you begin to ready yourself for danger, it covers you." +
            "You being to feel lighter, the ground begins to shake, until you can no longer feel as you come face to face" +
            " with a massive blinking white light.A booming choir of great beings speaks, 'Oh a violent one, a delectable one, " +
            "a stupid one.Your rarity must be put to test.' ";
    }

    public override void BodyTrigger()
    {
        PlayerStats.instance.Body -= CardBase.BodyMod;
        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/UnderConstruction"));
        //Fail State

    }

    public override void MindTrigger()
    {
        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/UnderConstruction"));
        //Does Nothing
    }
}
