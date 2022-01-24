using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "Deck", menuName = "AdventureDeck")]
public class Deck : ScriptableObject
{
    public int Runs;
    public int Deaths; 
    /// <summary>
    /// The Cards listed in the deck's scriptable object are events that are not relient on player agency. 
    /// </summary>
    public List<Card> AdventureCards; 
}