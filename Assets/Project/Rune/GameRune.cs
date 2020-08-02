using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRune : Rune, IHideable
{

    public RuneTrait RuneTrait;
    public RuneType RuneType;

    public GameRuneConfiguration Configuration;

    private RuneTrait currentRuneTrait;
    private RuneType currentRuneType;
    private GameObject compositeRune; 

    // Start is called before the first frame update
    void Start()
    {
        UpdateCompositeRune();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRuneTrait != RuneTrait || currentRuneType != RuneType ) {
            UpdateCompositeRune();
        }
    }

    void UpdateCompositeRune() {
        if( compositeRune != null ) {
            Destroy(compositeRune);
            compositeRune = null;
        }

        compositeRune = Instantiate(Configuration.RuneTypePrefab(RuneType), transform);
        MeshRenderer meshRenderer = compositeRune.GetComponent<MeshRenderer>();
        meshRenderer.material = Configuration.RuneTraitMaterial(RuneTrait);

        currentRuneTrait = RuneTrait;
        currentRuneType = RuneType;

        RuneName = GetStringValue(RuneTrait) + " " + GetStringValue(RuneType);

        compositeRune.SetActive(!_hidden);
    }

    public string GetStringValue(Enum value)
    {
        Type type = value.GetType();

        //Look for our 'StringValueAttribute' 
        //in the field's custom attributes
        FieldInfo fi = type.GetField(value.ToString());
        StringValueAttribute[] attrs = 
            fi.GetCustomAttributes(typeof (StringValueAttribute), 
                                    false) as StringValueAttribute[];
        if (attrs.Length > 0)
        {
            return attrs[0].StringValue;
        }

        return null;
    }

    #region IHideable

    private bool _hidden;
    public void SetHidden(bool value)
    {
        _hidden = value;
        if (compositeRune) { compositeRune.SetActive(!value); }
    }

    #endregion
}
