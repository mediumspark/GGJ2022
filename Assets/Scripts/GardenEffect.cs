using UnityEngine;

public class GardenEffect : EventCardEffect
{
    public override void BodyTrigger()
    {
        PlayerStats.instance.Body -= CardBase.BodyMod;

        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Garden"));
        FindObjectOfType<UIManager>().DescisionResult.text = " You're out of breath. Do you really think strength will get you through this trial? ";

    }

    public override void MindTrigger()
    {
        base.MindTrigger();

        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/GardenEnd"));
        //Does Nothing
    }
}
