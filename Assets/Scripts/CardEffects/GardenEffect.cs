using UnityEngine;
using System.Linq; 
public class GardenEffect : EventCardEffect
{
    public override void BodyTrigger()
    {
        PlayerStats.instance.Body -= CardBase.BodyMod;
        
        DeckManager.instance.AdventureDeck.Insert(1, Resources.Load<Card>("ScriptableObjects/Cards/AdventureCards/EndlessMischief"));
        DeckManager.instance.AdventureDeck.Insert(2, Resources.Load<Card>("ScriptableObjects/Cards/AdventureCards/Garden"));
        FindObjectOfType<UIManager>().DescisionResult.text = "You run and turn, run and turn, run and turn simply to end up right where you began";
        //Fail State

    }

    public override void MindTrigger()
    {
        base.MindTrigger();
        if (!DeckManager.instance.AdventureDeck.Where(ctx => ctx.EffectName == "GardenEnd").Any())
            DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/AdventureCards/GardenEnd"));
        FindObjectOfType<UIManager>().DescisionResult.text = "";

        //Does Nothing
    }
}
