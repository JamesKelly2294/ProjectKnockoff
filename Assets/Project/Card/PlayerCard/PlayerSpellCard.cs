using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSpellCard : Card
{
    
    public List<CardRuneSlot> Slots;

    public CardRuneSlot MainSlot { get { return Slots.Count > 0 ? Slots[0] : null; } }
    public CardRuneSlot TopLeftSlot { get { return Slots.Count > 1 ? Slots[1] : null; } }
    public CardRuneSlot TopRightSlot { get { return Slots.Count > 2 ? Slots[2] : null; } }
    public CardRuneSlot BottomLeftSlot { get { return Slots.Count > 3 ? Slots[3] : null; } }
    public CardRuneSlot BottomRightSlot { get { return Slots.Count > 4 ? Slots[4] : null; } }
    
    public new void SetHidden(bool value)
    {
        if (_hidden == value) { return; }
        base.SetHidden(value);
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
        CardName = Slots.First().DebugString();
        string debug = "";
        foreach (var slot in Slots.Skip(1))
        {
            debug +=  " - " + slot.DebugString() + "\n";
        }
        CardDescription = debug;
        
        UpdateText();
    }
}