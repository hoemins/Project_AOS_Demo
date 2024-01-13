using Hoemin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Skill
{
    [SerializeField] SkillData data;

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


