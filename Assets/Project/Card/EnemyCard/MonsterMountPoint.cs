using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMountPoint : MonoBehaviour
{

    public MonsterConfiguration MonsterConfiguration;
    public MonsterType MonsterType;
    private GameObject monster;

    private MonsterType currentMonsterType;

    // Start is called before the first frame update
    void Start()
    {
        monster = Instantiate(MonsterConfiguration.MonsterPrefab(MonsterType), transform);
        currentMonsterType = MonsterType;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMonsterType != MonsterType) {
            Destroy(monster);
            monster = Instantiate(MonsterConfiguration.MonsterPrefab(MonsterType), transform);
            currentMonsterType = MonsterType;
        }
    }
}

public enum MonsterType {
    MrAngles,
    MrKilly
}

[Serializable]
public struct MonsterConfiguration
{
    public GameObject MrAnglesPrefab;
    public GameObject MrKillyPrefab;

    public GameObject MonsterPrefab(MonsterType monsterType) {
        switch (monsterType)
        {
            case MonsterType.MrAngles:
                return MrAnglesPrefab;
            case MonsterType.MrKilly:
                return MrKillyPrefab;
            default:
                return null;
        }
    }
}