using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
[System.Serializable]
public class DeckGenerator 
{
    Card[] CardDatabase;

    public DeckGenerator()
    {
        CardDatabase = Resources.LoadAll<Card>("ScriptableObjects/Cards");
    }

    public Card ItemGeneration()
    {
        System.Random rand = new System.Random();
        List<Card> Items = CardDatabase.Where
            (
                ctx => ctx.CardType == CardType.ItemCard
            ).ToList();

        return Items[rand.Next(0, Items.Count)];
    }

    public Card EventGenerator()
    {
        System.Random rand = new System.Random();
        List<Card> Items = CardDatabase.Where
            (
                ctx => ctx.CardType == CardType.EventCard
            ).ToList();
        return Items[rand.Next(0, Items.Count)];
    }
}
