using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Israel : Champion
{
    public override void Awake()
    {
        base.Awake();
        InitChampionStats();
    }
    private void Start()
    {
        SetSkill();
    }

    public override void SetSkill()
    {
        SkillList.Add(new Israel_QSkill(this));
        SkillList.Add(new Israel_WSkill(this));
        SkillList.Add(new Israel_ESkill(this));
        SkillList.Add(new Israel_RSkill(this));
    }

    public override void InitChampionStats()
    {
        championStats.MaxHp = 600;
        championStats.MaxMp = 375;
        championStats.CurHp = championStats.MaxHp;
        championStats.CurMp = championStats.MaxMp;
    }

    public override void InitChampionInfo()
    {
        championinfo.Name = "Israel";
        championinfo.Level = 1;
        championinfo.PhysicalAtk = 62;
        championinfo.AbilityAtk = 15;
        championinfo.PhsicalDef = 24;
        championinfo.MagicalResistance = 30;
        championinfo.AbilityHaste = 0;
        championinfo.CriticalChance = 0.15f; 
    }
}
