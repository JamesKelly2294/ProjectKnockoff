using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public int Capacity = 5;
    public List<Card> Cards;
    public PlayerDeck Deck;

    // Start is called before the first frame update
    void Start()
    {
        Cards = new List<Card>(Capacity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
