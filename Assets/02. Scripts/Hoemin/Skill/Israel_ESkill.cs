using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Israel_ESkill : DirectSkill
{

    Action Attack;

    public Israel_ESkill(Champion owner) : base(owner)
    {
    }

    public override void Fire()
    {
        Attack();
    }

    public void AddAttackEvent( Action addAction )
    {
        Attack += addAction;
    }

    public override void SkillInit()
    {
        name = "Vision movement";
        level = 1;
        requiredLevel = 1;
        comsumeMP = 30;
        coolTime = 15f;
    }
}
