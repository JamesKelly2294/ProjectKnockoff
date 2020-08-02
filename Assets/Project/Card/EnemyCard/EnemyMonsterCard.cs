using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyMonsterCard : EnemyCard
{

    public MonsterType MonsterType;
    public MonsterMountPoint MonsterMountPoint;

    private MonsterType _monsterType;

    public TextMeshPro StatsTMP;

    public int Attack = 1;
    public int Health = 1;

    private int _attack;
    private int _health;

    // Start is called before the first frame update
    protected new void Start()
    {
        UpdateMonster();
        UpdateStatus();
        base.Start();
    }

    // Update is called once per frame
    protected new void Update()
    {
        if (_monsterType != MonsterType) {
            UpdateMonster();
        }

        if (_attack != Attack || _health != Health ) {
            UpdateStatus();
        }

        base.Update();
    }

    protected void UpdateMonster() {
        MonsterMountPoint.MonsterType = MonsterType;
        _monsterType = MonsterType;

        CardName = MonsterType.ToString();
    }

    protected void UpdateStatus() {
        StatsTMP.SetText(Attack + " / " + Health);
        _attack = Attack;
        _health = Health;
    }
}
