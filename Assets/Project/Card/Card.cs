using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Card : MonoBehaviour, IHideable
{

    public TextMeshPro TitleTMP;
    public TextMeshPro FlavorTextTMP;

    public string CardName;
    public string CardDescription;

    private string _cardName;
    private string _cardDescription;

    protected bool _hidden;
    virtual public void SetHidden(bool value)
    {

    }

    // Start is called before the first frame update
    protected void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    protected void Update()
    {
        UpdateText();
    }

    protected void UpdateText() {
        if (_cardName != CardName || _cardDescription != CardDescription ) {
            TitleTMP.SetText(CardName);
            FlavorTextTMP.SetText(CardDescription);

            _cardName = CardName;
            _cardDescription = CardDescription;
        }
    }
}
