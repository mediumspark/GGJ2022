using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI DeckUI, MindUI, BodyUI; //These are temporary and just for mobile testing;

    public TextMeshProUGUI DescisionResult;
    public GameObject GameOverScreen; 

    private void Update()
    {
        DeckUI.text = "Cards in Deck: " + PlayerStats.instance.HoldDeck.Count;
        MindUI.text = "Mind \n" + PlayerStats.instance.Mind;
        BodyUI.text = "Body \n" + PlayerStats.instance.Body;
    }

}
