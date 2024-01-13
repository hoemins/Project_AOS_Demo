using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SKILL_INDEX
{
    Q,W,E,R
}

public abstract class Skill
{
    protected Sprite skillImg;
    protected string name;
    protected uint level;
    protected uint requiredLevel;
    protected int comsumeMP;
    protected float coolTime;
    private bool isCool;

    Champion owner;

    public Champion Owner { get { return owner; } }
    public bool IsCool { get { return isCool; } set { isCool = value; } }
    public Skill(Champion owner)
    {
        this.owner = owner;
    }

    public abstract void InvokeSkill();
    public abstract void SkillInit();
}


