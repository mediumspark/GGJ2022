using UnityEngine;

public class TheGreatPitEffect_1 : EventCardEffect 
{
    private void Awake()
    {
        FindObjectOfType<UIManager>().DescisionResult.text = "You struggle with the door," +
            " giving it many pushes and pulls until it finally comes off its hinges," +
            " but something has linked you to it and you begin to tumble down into an abyss, " +
            "and after minutes of darkness you hit what feels like earth. To your dismay, this fall somehow leaves you uninjured." +
            " A being that has blended into the darkness glares at you intense glowing eyes lie before you";
    }

    public override void BodyTrigger()
    {
        PlayerStats.instance.Body -= CardBase.BodyMod;

        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/AdventureCards/TokenNightmare"));
        FindObjectOfType<UIManager>().DescisionResult.text = "";

        //Fail State

    }

    public override void MindTrigger()
    {
        base.MindTrigger();
        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/AdventureCards/TheBumpInTheDarkness"));
        FindObjectOfType<UIManager>().DescisionResult.text = "";

        //Does Nothing
    }
}
