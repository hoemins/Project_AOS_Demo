using Hoemin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Skill
{
    public SkillType skillType;
    protected Sprite skillImg;
    protected string name;
    protected uint level;
    protected uint requiredLevel;
    protected int comsumeMP;
    protected float coolTime;

    public IndicatorRenderer indicatorRenderer;
    Champion owner;

    public Champion Owner { get { return owner; } }
  
    public Skill(Champion owner)
    {
        this.owner = owner;
    }

    public abstract void Fire();
    public abstract void SkillInit();
}

public abstract class DirectSkill : Skill
{
    public DirectSkill(Champion owner) : base(owner)
    {
        skillType = SkillType.DIRECT;
    }
}

public abstract class WaitSkill : Skill
{

    public WaitSkill(Champion owner) : base(owner)
    {
        skillType = SkillType.DIRECT;
    }

}
