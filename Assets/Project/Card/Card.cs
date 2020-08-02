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

    protected bool _hidden;
    public void SetHidden(bool value)
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
        
    }

    protected void UpdateText() {
        TitleTMP.SetText(CardName);
        FlavorTextTMP.SetText(CardDescription);
    }
}
