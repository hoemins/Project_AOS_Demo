using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Israel_QSkill : WaitSkill
{
    Vector3 firePos;

    public Israel_QSkill(Champion owner) : base(owner)
    {
    }

    public override void SkillInit()
    {
        name = "mystic arrow";
        level = 1;
        requiredLevel = 1;
        comsumeMP = 10;
        firePos = Owner.transform.position + Vector3.up * 0.5f;
    }
    public override void Fire()
    {
        
    }
}
