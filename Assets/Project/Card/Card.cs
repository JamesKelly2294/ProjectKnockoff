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

    private bool _hidden;
    public void SetHidden(bool value)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText() {
        TitleTMP.SetText(CardName);
        FlavorTextTMP.SetText(CardDescription);
    }
}
