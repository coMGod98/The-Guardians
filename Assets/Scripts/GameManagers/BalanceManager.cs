using System;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Normal, Boss
}

public enum UnitType
{
    Warrior_Common = 0, Warrior_Uncommon, Warrior_Rare, Warrior_Epic, Warrior_Legendary,
    Archer_Common = 10, Archer_Uncommon, Archer_Rare, Archer_Epic, Archer_Legendary,
    Wizard_Common = 20, Wizard_Uncommon, Wizard_Rare, Wizard_Epic, Wizard_Legendary
}

public enum UnitJob
{
    Warrior, Archer, Wizard
}

public enum UnitRank
{
    Common, Uncommon, Rare, Epic, Legendary
}

public enum BulletShootingType
{
    Follow, Straight
}

public enum BulletHitCheck
{
    Targeting, Moving
}

[Serializable]
public struct UnitData
{
    public UnitType type;
    public UnitJob job;
    public UnitRank rank;
    public List<float> attackDamage;
    public float attackSpeed;
    public float attackRange;
    public float attackDuration;
    public float bulletSpawnTime;
    public float attackCoolTime;
    public int salesGold;
    public int bulletKey;
}

[Serializable]
public struct MonsterData
{
    public string round;
    public float HP;
    public int Gold;
    public float Speed;
}

[Serializable]
public struct BulletData
{
    public int key;
    public BulletShootingType shootingType;
    public BulletHitCheck hitCheck;
    public float scale;
    public float damageCoefficient;
    public float hitRange;
    public float speed;
    public int attackableNumber;
}

public class BalanceManager : MonoBehaviour
{
    public Dictionary<UnitType, UnitData> unitDic;
    public Dictionary<string, MonsterData> monsterDic;
    public Dictionary<int, BulletData> bulletDic;

    public void Init()
    {
        SaveUnitData();
        SaveMonsterData();
        SaveBulletData();
    }

    void SaveUnitData()
    {
        unitDic = new Dictionary<UnitType, UnitData>();
        UnitData unitData = new UnitData();

        // 전사
        List<float> warriorAttackDamageList = new List<float>();
        UnitDamageList(warriorAttackDamageList, 7);
        
        // Common
        unitData.type = UnitType.Warrior_Common;
        unitData.job = UnitJob.Warrior;
        unitData.rank = UnitRank.Common;
        unitData.attackDamage = warriorAttackDamageList;
        unitData.attackSpeed = 1.0f;
        unitData.attackRange = 7.0f;
        unitData.attackDuration = 1.5f;
        unitData.bulletSpawnTime = 0.7f;
        unitData.attackCoolTime = 3.0f;
        unitData.salesGold = 5;
        unitData.bulletKey = 1;

        unitDic[unitData.type] = unitData;

        // Uncommon
        unitData.type = UnitType.Warrior_Uncommon;
        unitData.job = UnitJob.Warrior;
        unitData.rank = UnitRank.Uncommon;
        unitData.attackDamage = warriorAttackDamageList;
        unitData.attackSpeed = 1.0f;
        unitData.attackRange = 7.0f;
        unitData.attackDuration = 1.5f;
        unitData.bulletSpawnTime = 0.7f;
        unitData.attackCoolTime = 3.0f;
        unitData.salesGold = 10;
        unitData.bulletKey = 2;

        unitDic[unitData.type] = unitData;

        // Rare
        unitData.type = UnitType.Warrior_Rare;
        unitData.job = UnitJob.Warrior;
        unitData.rank = UnitRank.Rare;
        unitData.attackDamage = warriorAttackDamageList;
        unitData.attackSpeed = 1.0f;
        unitData.attackRange = 7.0f;
        unitData.attackDuration = 1.5f;
        unitData.bulletSpawnTime = 0.7f;
        unitData.attackCoolTime = 3.0f;
        unitData.salesGold = 15;
        unitData.bulletKey = 3;

        unitDic[unitData.type] = unitData;

        // Epic
        unitData.type = UnitType.Warrior_Epic;
        unitData.job = UnitJob.Warrior;
        unitData.rank = UnitRank.Epic;
        unitData.attackDamage = warriorAttackDamageList;
        unitData.attackSpeed = 2.0f;
        unitData.attackRange = 12.0f;
        unitData.attackDuration = 1.5f;
        unitData.bulletSpawnTime = 0.7f;
        unitData.attackCoolTime = 3.0f;
        unitData.salesGold = 20;
        unitData.bulletKey = 4;

        unitDic[unitData.type] = unitData;

        // Legendary
        unitData.type = UnitType.Warrior_Legendary;
        unitData.job = UnitJob.Warrior;
        unitData.rank = UnitRank.Legendary;
        unitData.attackDamage = warriorAttackDamageList;
        unitData.attackSpeed = 3.0f;
        unitData.attackRange = 20.0f;
        unitData.attackDuration = 1.5f;
        unitData.bulletSpawnTime = 0.7f;
        unitData.attackCoolTime = 3.0f;
        unitData.salesGold = 25;
        unitData.bulletKey = 5;

        unitDic[unitData.type] = unitData;

        
        // 궁수
        List<float> archerAttackDamageList = new List<float>();
        UnitDamageList(archerAttackDamageList, 5);

        // Common
        unitData.type = UnitType.Archer_Common;
        unitData.job = UnitJob.Archer;
        unitData.rank = UnitRank.Common;
        unitData.attackDamage = archerAttackDamageList;
        unitData.attackSpeed = 1.0f;
        unitData.attackRange = 7.0f;
        unitData.attackDuration = 1.0f;
        unitData.bulletSpawnTime = 0.6f;
        unitData.attackCoolTime = 2.0f;
        unitData.salesGold = 5;
        unitData.bulletKey = 1;

        unitDic[unitData.type] = unitData;
        
        // Uncommon
        unitData.type = UnitType.Archer_Uncommon;
        unitData.job = UnitJob.Archer;
        unitData.rank = UnitRank.Uncommon;
        unitData.attackDamage = archerAttackDamageList;
        unitData.attackSpeed = 1.0f;
        unitData.attackRange = 7.0f;
        unitData.attackDuration = 1.0f;
        unitData.bulletSpawnTime = 0.6f;
        unitData.attackCoolTime = 2.0f;
        unitData.salesGold = 10;
        unitData.bulletKey = 2;

        unitDic[unitData.type] = unitData;

        // Rare
        unitData.type = UnitType.Archer_Rare;
        unitData.job = UnitJob.Archer;
        unitData.rank = UnitRank.Rare;
        unitData.attackDamage = archerAttackDamageList;
        unitData.attackSpeed = 1.0f;
        unitData.attackRange = 7.0f;
        unitData.attackDuration = 1.0f;
        unitData.bulletSpawnTime = 0.6f;
        unitData.attackCoolTime = 2.0f;
        unitData.salesGold = 15;
        unitData.bulletKey = 3;

        unitDic[unitData.type] = unitData;

        // Epic
        unitData.type = UnitType.Archer_Epic;
        unitData.job = UnitJob.Archer;
        unitData.rank = UnitRank.Epic;
        unitData.attackDamage = archerAttackDamageList;
        unitData.attackSpeed = 2.0f;
        unitData.attackRange = 12.0f;
        unitData.attackDuration = 1.0f;
        unitData.bulletSpawnTime = 0.6f;
        unitData.attackCoolTime = 2.0f;
        unitData.salesGold = 20;
        unitData.bulletKey = 4;

        unitDic[unitData.type] = unitData;

        // Legendary
        unitData.type = UnitType.Archer_Legendary;
        unitData.job = UnitJob.Archer;
        unitData.rank = UnitRank.Legendary;
        unitData.attackDamage = archerAttackDamageList;
        unitData.attackSpeed = 3.0f;
        unitData.attackRange = 20.0f;
        unitData.attackDuration = 1.0f;
        unitData.bulletSpawnTime = 0.6f;
        unitData.attackCoolTime = 2.0f;
        unitData.salesGold = 25;
        unitData.bulletKey = 5;

        unitDic[unitData.type] = unitData;


        // 마법사
        List<float> wizardAttackDamageList = new List<float>();
        UnitDamageList(wizardAttackDamageList, 9);
        
        // Common
        unitData.type = UnitType.Wizard_Common;
        unitData.job = UnitJob.Wizard;
        unitData.rank = UnitRank.Common;
        unitData.attackDamage = wizardAttackDamageList;
        unitData.attackSpeed = 1.0f;
        unitData.attackRange = 7.0f;
        unitData.attackDuration = 2.0f;
        unitData.bulletSpawnTime = 1.2f;
        unitData.attackCoolTime = 4.0f;
        unitData.salesGold = 5;
        unitData.bulletKey = 1;

        unitDic[unitData.type] = unitData;

        // Uncommon
        unitData.type = UnitType.Wizard_Uncommon;
        unitData.job = UnitJob.Wizard;
        unitData.rank = UnitRank.Uncommon;
        unitData.attackDamage = wizardAttackDamageList;
        unitData.attackSpeed = 1.0f;
        unitData.attackRange = 7.0f;
        unitData.attackDuration = 2.0f;
        unitData.bulletSpawnTime = 1.2f;
        unitData.attackCoolTime = 4.0f;
        unitData.salesGold = 10;
        unitData.bulletKey = 2;

        unitDic[unitData.type] = unitData;

        // Rare
        unitData.type = UnitType.Wizard_Rare;
        unitData.job = UnitJob.Wizard;
        unitData.rank = UnitRank.Rare;
        unitData.attackDamage = wizardAttackDamageList;
        unitData.attackSpeed = 1.0f;
        unitData.attackRange = 7.0f;
        unitData.attackDuration = 2.0f;
        unitData.bulletSpawnTime = 1.2f;
        unitData.attackCoolTime = 4.0f;
        unitData.salesGold = 15;
        unitData.bulletKey = 3;

        unitDic[unitData.type] = unitData;
        
        // Epic
        unitData.type = UnitType.Wizard_Epic;
        unitData.job = UnitJob.Wizard;
        unitData.rank = UnitRank.Epic;
        unitData.attackDamage = wizardAttackDamageList;
        unitData.attackSpeed = 2.0f;
        unitData.attackRange = 12.0f;
        unitData.attackDuration = 2.0f;
        unitData.bulletSpawnTime = 1.2f;
        unitData.attackCoolTime = 4.0f;
        unitData.salesGold = 20;
        unitData.bulletKey = 4;

        unitDic[unitData.type] = unitData;

        // Legendary
        unitData.type = UnitType.Wizard_Legendary;
        unitData.job = UnitJob.Wizard;
        unitData.rank = UnitRank.Legendary;
        unitData.attackDamage = wizardAttackDamageList;
        unitData.attackSpeed = 3.0f;
        unitData.attackRange = 20.0f;
        unitData.attackDuration = 2.0f;
        unitData.bulletSpawnTime = 1.2f;
        unitData.attackCoolTime = 4.0f;
        unitData.salesGold = 25;
        unitData.bulletKey = 5;

        unitDic[unitData.type] = unitData;
    }

   public void UnitDamageList(List<float> list, float dmg)
    {
        for(int i = 0; i < 20; i++)
        {
            if(i != 0) dmg += 5;
            list.Add(dmg);
        }
    }

    void SaveMonsterData()
    {
        monsterDic = new Dictionary<string, MonsterData>();
        MonsterData monsterData = new MonsterData();
        for(int i = 1; i < GameWorld.Instance.totalRounds + 1; i++)
        {
            monsterData.round = "Round" + i;
            monsterData.HP = (i % 5 == 0) ? 1000 * i : 100 * i;
            monsterData.Gold = (i % 5 == 0) ? 200 * i : 2 * i;
            monsterData.Speed = (i % 5 == 0) ? 3.0f : 6.0f;
            monsterDic[monsterData.round] = monsterData;
        }
    }

    void SaveBulletData()
    {
        bulletDic = new Dictionary<int, BulletData>();
        BulletData bulletData = new BulletData();

        // Common
        bulletData.key = 1;
        bulletData.shootingType = BulletShootingType.Follow;
        bulletData.hitCheck = BulletHitCheck.Targeting;
        bulletData.scale = 1.0f;
        bulletData.damageCoefficient = 0.5f;
        bulletData.hitRange = 1.0f; // 나중에 프리팹의 크기에 맞춰주기
        bulletData.speed = 15.0f;
        bulletData.attackableNumber = 1;

        bulletDic[bulletData.key] = bulletData;

        // Uncommon
        bulletData.key = 2;
        bulletData.shootingType = BulletShootingType.Follow;
        bulletData.hitCheck = BulletHitCheck.Targeting;
        bulletData.scale = 1.0f; // 생각
        bulletData.damageCoefficient = 0.8f;
        bulletData.hitRange = 1.0f; // 나중에 프리팹의 크기에 맞춰주기
        bulletData.speed = 15.0f;
        bulletData.attackableNumber = 1;

        bulletDic[bulletData.key] = bulletData;

        // Rare
        bulletData.key = 3;
        bulletData.shootingType = BulletShootingType.Straight;
        bulletData.hitCheck = BulletHitCheck.Moving;
        bulletData.scale = 3.0f;
        bulletData.damageCoefficient = 0.8f;
        bulletData.hitRange = 4.0f; // 나중에 프리팹의 크기에 맞춰주기
        bulletData.speed = 15.0f;
        bulletData.attackableNumber = 3;

        bulletDic[bulletData.key] = bulletData;

        // Epic
        bulletData.key = 4;
        bulletData.shootingType = BulletShootingType.Straight;
        bulletData.hitCheck = BulletHitCheck.Moving;
        bulletData.scale = 3.0f; // 생각
        bulletData.damageCoefficient = 1.0f;
        bulletData.hitRange = 4.0f; // 나중에 프리팹의 크기에 맞춰주기
        bulletData.speed = 15.0f;
        bulletData.attackableNumber = 5;    

        bulletDic[bulletData.key] = bulletData;    

        // Legendary
        bulletData.key = 5;
        bulletData.shootingType = BulletShootingType.Follow;
        bulletData.hitCheck = BulletHitCheck.Moving;
        bulletData.scale = 4.0f;
        bulletData.damageCoefficient = 1.2f;
        bulletData.hitRange = 5.0f;
        bulletData.speed = 15.0f;
        bulletData.attackableNumber = 20;       

        bulletDic[bulletData.key] = bulletData; 
    }
}
