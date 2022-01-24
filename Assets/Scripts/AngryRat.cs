using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryRat : EventCardEffect
{
    public override void BodyTrigger()
    {
        PlayerStats.instance.Body -= CardBase.BodyMod;
        PlayerStats.instance.Mind--;

        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Garden"));
        FindObjectOfType<UIManager>().DescisionResult.text = " You crush the mischief of vile creatures underheal one at a time";

        base.BodyTrigger();
    }

    public override void MindTrigger()
    {     
        PlayerStats.instance.Mind -= CardBase.MindMod;
        DeckManager.instance.AdventureDeck.Insert(1, Resources.Load<Card>("ScriptableObjects/AngryRat"));
        FindObjectOfType<UIManager>().DescisionResult.text = " The horde seems endless, the more you turn to run the more seem to appear.";

        base.MindTrigger();
    }
}