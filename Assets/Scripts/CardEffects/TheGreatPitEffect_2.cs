using UnityEngine;

public class TheGreatPitEffect_2 : EventCardEffect 
{

    private void Awake()
    {
        FindObjectOfType<UIManager>().DescisionResult.text = "You brace yourself, about to give the doorknob a solid kick, " +
            "but just as your foot hit’s its mark the door swings and you find yourself engulfed in darkness, falling for what " +
            "feels like an eternity. You hit the ground with a massive thud," +
            " face looking up to the door to a garden and a light that no longer exists. You attempt to pick yourself up";
    }

    public override void BodyTrigger()
    {
        PlayerStats.instance.Body -= CardBase.BodyMod;

        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/AdventureCards/TheBumpInTheDarkness"));
        FindObjectOfType<UIManager>().DescisionResult.text = "You run and turn, run and turn, run and turn simply to end up right where you began";
        //Fail State

    }

    public override void MindTrigger()
    {
        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/AdventureCards/TheBumpInTheDarkness"));
        FindObjectOfType<UIManager>().DescisionResult.text = "";
        //Does Nothing
    }
}
