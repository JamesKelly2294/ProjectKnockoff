using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldRuneSlot : RuneSlot
{
    public GameObject RunePrefab;
    public Transform RuneLocation;
    public bool SpawnRuneOnStart;

    private GameRune _rune;

    // Start is called before the first frame update
    void Start()
    {
        if (SpawnRuneOnStart)
        {
            SpawnRune();
        }
    }

    void SpawnRune()
    {
        if (_rune) { return; }
        GameObject runeGO = Instantiate(RunePrefab);
        runeGO.transform.parent = RuneLocation;
        runeGO.transform.localPosition = Vector3.zero;
        runeGO.transform.localScale = Vector3.one;

        FloatAnimation floatAnimation = runeGO.AddComponent<FloatAnimation>();
        floatAnimation.offset = new Vector3(0, 0.005f, 0);

        GameRune rune = runeGO.GetComponent<GameRune>();
        rune.RuneTrait = RuneTrait.Common;

        Array values = Enum.GetValues(typeof(RuneType));
        rune.RuneType = (RuneType)values.GetValue(UnityEngine.Random.Range(0, values.Length - 1));

        _rune = rune;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
