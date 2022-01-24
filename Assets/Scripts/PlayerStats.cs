using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance; 

    public List<Card> HoldDeck;
    public int Mind, Body;

    private void Awake()
    {
        instance = this; 
    }

    public void PlayCard()
    {
        DeckManager.instance.CurrentCardEffect.MindMod -= HoldDeck[0].MindMod;
        DeckManager.instance.CurrentCardEffect.BodyMod -= HoldDeck[0].BodyMod;
        HoldDeck.RemoveAt(0);
    }

    public string EndAdventure()
    {
        string AdventureSummary = "";

        if (Mind > Body)
        {
            if (Mind < 10)
            {
                AdventureSummary = "You arrive at your destination body broken looking for something to help you survive this endless adventure";
            }
            else if (Mind > 10 && Mind < 50)
            {

            }
            else if (Mind > 50 && Mind < 100)
            {

            }
            else
            {

            }

        }
        else if (Mind < Body)
        {

            if (Body < 10)
            {

            }
            else if (Body > 10 && Body < 50)
            {

            }
            else if (Body > 50 && Body < 100)
            {

            }
            else
            {

            }
        }
        else
        {
            if (Body < 10)
            {

            }
            else if (Body > 10 && Body < 50)
            {

            }
            else if (Body > 50 && Body < 100)
            {

            }
            else
            {

            }
        }

        return AdventureSummary; 
    }
}
