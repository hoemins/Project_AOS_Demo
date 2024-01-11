using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Israel_WSkill : WaitSkill
{
    Vector3 firePos;
    public Israel_WSkill(Champion owner) : base(owner)
    {
    }

    public override void Fire()
    {
       
    }

    public override void SkillInit()
    {
        name = "Flow of essence";
        level = 1;
        requiredLevel = 1;
        comsumeMP = 20;
        coolTime = 10f;
        firePos = Owner.transform.position + Vector3.up; // offset ∏¬√Á¡÷±‚
    }
}

