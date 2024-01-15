using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Israel_WSkill : Skill
{
    private float skillRange = 10f;

    public float SkillRange { get; }

    public override void InvokeSkill()
    {
        Owner.Anim.Play("Wskill");
        Debug.Log(Data.skillEffect[1]);
        Instantiate(Data.skillEffect[1], Owner.transform.position, Quaternion.identity);
    }

}

