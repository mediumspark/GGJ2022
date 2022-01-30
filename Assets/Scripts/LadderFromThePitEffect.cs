using UnityEngine;

public class LadderFromThePitEffect : EventCardEffect 
{
    private void Awake()
    {
        FindObjectOfType<UIManager>().DescisionResult.text =
           "Head pounding with the knowledge of risks unknown, you hesitate.Before your very eyes the door swings open," +
           " and the little creature quickly disappears within it screaming the way down.Before you know it the door closes" +
           " and the voice is silent.A bright light appears and it reopens slowly. A latter showing from the top, with sounds " +
           "of drunken joy, and merriment coming from underneath it.";
    }

    public override void BodyTrigger()
    {
        PlayerStats.instance.Body -= CardBase.BodyMod;
        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/UnderConstruction"));
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
