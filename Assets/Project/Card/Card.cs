using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{

    public List<CardRuneSlot> Slots;
    public TextMeshPro TitleTMP;
    public TextMeshPro FlavorTextTMP;
    public CardDescription CardDescription;
    
    // Start is called before the first frame update
    void Start()
    {
        TitleTMP.SetText(CardDescription.Name);
        FlavorTextTMP.SetText(CardDescription.FlavorText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public struct CardDescription {
    public string Name;
    public string FlavorText;
}