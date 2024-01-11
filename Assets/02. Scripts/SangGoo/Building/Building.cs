using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo
{
    private string bName;
    private int maxHp;
    private int hp;
    private int phsicalDef;
    private int magicalResistance;

    public string BName => bName;
    public int MaxHp => maxHp;
    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
        }
    }
    public int PhsicalDef => phsicalDef;
    public int MagicalResistance => magicalResistance;

    public BuildingInfo(string bName, int hp, int phsicalDef, int magicalRsistance)
    {
        this.bName = bName;
        this.maxHp = hp;
        this.hp = hp;
        this.phsicalDef = phsicalDef;
        this.magicalResistance = magicalRsistance;
    }
}

public class Building : MonoBehaviour, IHitable
{
    public BuildingInfo buildingInfo;
    
    public Action OnDestroy;
    public Action<int> OnHit;

    public int Hp
    {
        get => buildingInfo.Hp;
        set
        {
            buildingInfo.Hp = value;
            if(buildingInfo.Hp <= 0)
            {
                Destroy();
            }
        }
    }

    protected void Start()
    {
        OnHit += (int value) => { Hp -= value; };
    }

    public void Hit(int value)
    {
        OnHit(value);
    }

    public void Destroy()
    {
        OnDestroy();
    }
}
