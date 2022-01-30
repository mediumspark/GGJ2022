using UnityEngine;

public class TokenNightmareEffect : EventCardEffect 
{
    private void Awake()
    {
        FindObjectOfType<UIManager>().DescisionResult.text = "It’s deep voice says to you, “Oh, you poor being....What is" +
            " it you need?” The eyes seem to disappear for a moment, and reappear somehow softer, waiting for a response from you.";
    }

    public override void BodyTrigger()
    {
        PlayerStats.instance.Body -= CardBase.BodyMod;
        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/AdventureCards/TheBumpInTheDarkness"));
        FindObjectOfType<UIManager>().DescisionResult.text = "";
        //Fail State

    }

    public override void MindTrigger()
    {
        DeckManager.instance.AdventureDeck.Add(Resources.Load<Card>("ScriptableObjects/Cards/AdventureCards/TorchGoblin"));
        FindObjectOfType<UIManager>().DescisionResult.text = "";
        //Does Nothing
    }
}
