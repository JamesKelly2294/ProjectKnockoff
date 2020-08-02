using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Card : MonoBehaviour, IHideable
{

    public List<CardRuneSlot> Slots;
    public TextMeshPro TitleTMP;
    public TextMeshPro FlavorTextTMP;
    public CardDescription CardDescription;

    public CardRuneSlot MainSlot { get { return Slots.Count > 0 ? Slots[0] : null; } }
    public CardRuneSlot TopLeftSlot { get { return Slots.Count > 1 ? Slots[1] : null; } }
    public CardRuneSlot TopRightSlot { get { return Slots.Count > 2 ? Slots[2] : null; } }
    public CardRuneSlot BottomLeftSlot { get { return Slots.Count > 3 ? Slots[3] : null; } }
    public CardRuneSlot BottomRightSlot { get { return Slots.Count > 4 ? Slots[4] : null; } }
    
    private bool _hidden;
    public void SetHidden(bool value)
    {
        if (_hidden == value) { return; }
        _hidden = value;

        transform.Find("Model").gameObject.SetActive(!_hidden);
        foreach(CardRuneSlot slot in Slots)
        {
            slot.SetHidden(_hidden);
        }
    }

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