using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    [SerializeField] NonPlayerUIController uiController;

    public Action OnDestroy;
    public Action<int> OnHit;

    public virtual int Hp
    {
        get => buildingInfo.Hp;
        set
        {
            buildingInfo.Hp = value;
            uiController.SetHpbar(buildingInfo.Hp, buildingInfo.MaxHp);
            if (buildingInfo.Hp <= 0)
            {
                Destroy();
            }
        }
    }

    public bool IsDie
    {
        get => isDie;
    }
    private bool isDie = false;

    protected void Start()
    {
        OnHit += (int value) => { Hp -= value; };
        //uiController.SetUIPos();
    }

    protected void Update()
    {
        uiController.SetUIPos();
    }

    public void Hit(int value)
    {
        OnHit(value);
    }

    public void Destroy()
    {
        isDie = true;
        OnDestroy();
    }
}
