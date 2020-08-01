using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRune : Rune
{

    public RuneTrait RuneTrait;
    public RuneType RuneType;

    public RuneTypePrefabs RuneTypePrefabs;
    public RuneTraitMaterials RuneTraitMaterials;
    
    private RuneTrait currentRuneTrait;
    private RuneType currentRuneType;
    private GameObject compositeRune; 

    // Start is called before the first frame update
    void Start()
    {
        UpdateCompositeRune();
        name = "Example";
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

        compositeRune = Instantiate(RuneTypePrefabs.RuneTypePrefab(RuneType), transform);
        MeshRenderer meshRenderer = compositeRune.GetComponent<MeshRenderer>();
        meshRenderer.material = RuneTraitMaterials.RuneTraitMaterial(RuneTrait);

        currentRuneTrait = RuneTrait;
        currentRuneType = RuneType;

        RuneName = GetStringValue(RuneTrait) + " " + GetStringValue(RuneType);
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
}

public enum RuneType {

    [StringValue("Healing")]
    Healing,            // Heal the main char

    [StringValue("Damage")]
    Damage,             // Increase the damage done to this spell

    [StringValue("Mana")]
    Mana,               // Gain mana this turn

    [StringValue("ReduceManaCost")]
    ReduceManaCost,     // This card uses less mana

    [StringValue("Actions")]
    Actions             // Gain another action this turn
}

[Serializable]
public struct RuneTypePrefabs {
    public GameObject HealingRunePrefab;
    public GameObject DamageRunePrefab;
    public GameObject ManaRunePrefab;
    public GameObject ReduceManaCostRunePrefab;
    public GameObject ActionsRunePrefab;

    public GameObject RuneTypePrefab(RuneType type) {
        switch (type)
        {
            case RuneType.Healing:
                return HealingRunePrefab;
            case RuneType.Damage:
                return DamageRunePrefab;
            case RuneType.Mana:
                return ManaRunePrefab;
            case RuneType.ReduceManaCost:
                return ReduceManaCostRunePrefab;
            case RuneType.Actions:
                return ActionsRunePrefab;
            default:
                return null;
        }
    }
}

public enum RuneTrait {

    [StringValue("Demonic")]
    Demonic,       // Red       // Helps the enemy (if balanced right, could interact with other RuneTraits)
    
    [StringValue("Lesser")]
    Lesser,        // Gray      // Provides useful amount of help with a downside
    
    [StringValue("Common")]
    Common,        // White     // Provides a useful amount of help
    
    [StringValue("Major")]
    Major,         // Red       // Provides a great amount of help
    
    [StringValue("Prestine")]
    Prestine,      // Blue      // Provides a great amount of help with a bonus outside of the main effect
    
    [StringValue("Angelic")]
    Angelic        // Purple    // Extremely useful
}

[Serializable]
public struct RuneTraitMaterials {
    public Material DemonicRuneTraitMaterial;
    public Material LesserRuneTraitMaterial;
    public Material CommonRuneTraitMaterial;
    public Material MajorRuneTraitMaterial;
    public Material PrestineRuneTraitMaterial;
    public Material AngelicRuneTraitMaterial;

    public Material RuneTraitMaterial(RuneTrait trait) {
        switch (trait)
        {
            case RuneTrait.Demonic:
                return DemonicRuneTraitMaterial;
            case RuneTrait.Lesser:
                return LesserRuneTraitMaterial;
            case RuneTrait.Common:
                return CommonRuneTraitMaterial;
            case RuneTrait.Major:
                return MajorRuneTraitMaterial;
            case RuneTrait.Prestine:
                return PrestineRuneTraitMaterial;
            case RuneTrait.Angelic:
                return AngelicRuneTraitMaterial;
            default:
                return null;
        }
    }
}

public class StringValueAttribute : System.Attribute {

    private string _value;

    public StringValueAttribute(string value) {
        _value = value;
    }

    public string StringValue {
        get { 
            return _value; 
        }
    }

}