using UnityEngine;

public class TrapDoorEffect : EventCardEffect
{
    private void Awake()
    {
        FindObjectOfType<UIManager>().DescisionResult.text = "The creature looks at you, still judging, but no longer" +
            " as a threat.It says “Come, Come.Follow Follow. It takes you took a ditch barely covered by a wooden trap door." +
            " “Down Down”. It begins to hop with an unsettling amount of joy at the prospect of your …. downfall.";
    }

    public override void BodyTrigger()
    {
        PlayerStats.instance.Body -= CardBase.BodyMod;
        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/LadderFromThePit"));
        FindObjectOfType<UIManager>().DescisionResult.text = "";
        //Fail State

    }

    public override void MindTrigger()
    {
        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/UnderConstruction"));
        FindObjectOfType<UIManager>().DescisionResult.text = "";
        //Does Nothing
    }
}
