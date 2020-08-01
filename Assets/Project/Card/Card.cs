using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Card : MonoBehaviour
{

    public List<CardRuneSlot> Slots;
    public TextMeshPro TitleTMP;
    public TextMeshPro FlavorTextTMP;
    public CardDescription CardDescription;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        CardDescription.Name = Slots.First().DebugString();
        string debug = "";
        foreach (var slot in Slots.Skip(1))
        {
            debug +=  " - " + slot.DebugString() + "\n";
        }
        CardDescription.FlavorText = debug;
        
        UpdateText();
    }

    void UpdateText() {
        TitleTMP.SetText(CardDescription.Name);
        FlavorTextTMP.SetText(CardDescription.FlavorText);
    }
}

[Serializable]
public struct CardDescription {
    public string Name;
    public string FlavorText;
}