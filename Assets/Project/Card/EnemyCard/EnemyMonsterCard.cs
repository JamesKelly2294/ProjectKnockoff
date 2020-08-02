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

        switch (MonsterType)
        {
            case MonsterType.MrAngles:
                CardName = "Mr. Angles";
                CardDescription = "His twirling arms allow him to quickly roll around the battlefield, tying your shoelaces to the other foot.";
                break;
            case MonsterType.MrKilly:
                CardName = "Mr. Killy";
                CardDescription = "Mr. Killy collects lasers, so far, he has thirteen. He's willing to pay handsomely for one, if it's rare enough.";
                break;
            case MonsterType.MrBall:
                CardName = "Mr. Ball";
                CardDescription = "He's been growing his raritanium perl for over a thousand years. Think you can take if from him? Many have died trying.";
                break;
            default:
                CardName = "Unknown ???";
                CardDescription = MonsterType.ToString();
                break;
        }


        
    }

    protected void UpdateStatus() {
        StatsTMP.SetText(Attack + " / " + Health);
        _attack = Attack;
        _health = Health;
    }
}
