﻿using System.Collections;
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
            deck.Add(CardFactory.MakeCard(RuneTrait.Common, trait[traitCounter]));
            traitCounter = (traitCounter + 1) % trait.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}