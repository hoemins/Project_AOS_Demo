using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Israel_QSkill : Skill
{
    private float skillRange = 10f;
 
    public float SkillRange { get; }



    public override void InvokeSkill()
    {
        Owner.Anim.Play("Qskill");
        Instantiate(Data.skillEffect[0], Owner.transform.position, Quaternion.identity);
    }

}
