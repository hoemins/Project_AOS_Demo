using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Israel_QSkill : WaitSkill
{
    GameObject skillEffect;
    Vector3 firePos;

    public Israel_QSkill(Champion owner) : base(owner) { }


    public override void SkillInit()
    {
        name = "Mystic arrow";
        level = 1;
        requiredLevel = 1;
        comsumeMP = 10;
        coolTime = 6f;
        firePos = Owner.transform.position + Vector3.up; // offset 맞춰주기
    }
    public override void Fire()
    {
        Debug.Log("이즈Q");
    }
}
