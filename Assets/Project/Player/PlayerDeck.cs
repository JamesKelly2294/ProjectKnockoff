using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    [Range(0, 10)]
    public int StartingSize = 7;

    [Range(0, 40)]
    public int MaximumSize = 20;

    public List<Card> deck;
    public List<Card> discard;
    public Transform DeckTop;

    private CardFactory CardFactory;

    // Start is called before the first frame update
    void Start()
    {
        deck = new List<Card>(MaximumSize);
        discard = new List<Card>(MaximumSize);
        CardFactory = FindObjectOfType<CardFactory>();

        CreateStartingDeck();
    }

    void CreateStartingDeck()
    {
        RuneType[] trait =
        {
            RuneType.Damage,
            RuneType.Mana,
        };

        int traitCounter = 0;
        for (int i = 0; i < StartingSize; i++)
        {
            Card card = CardFactory.MakePlayerCard(RuneTrait.Common, trait[traitCounter]);
            card.SetHidden(true);
            card.transform.position = DeckTop.transform.position;
            card.transform.rotation = DeckTop.transform.rotation;
            deck.Add(card);

            traitCounter = (traitCounter + 1) % trait.Length;
        }
    }

    public Card DrawCard()
    {
        if (deck.Count == 0)
        {
            // TODO: shuffle deck from discard pile
            return null;
        }

        Card card = deck[deck.Count - 1];
        deck.RemoveAt(deck.Count - 1);

        Debug.Log("Drew " + card + " from deck.");

        return card;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
