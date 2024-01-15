using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Israel_RSkill : Skill
{

    private float skillRange = Mathf.Infinity;


    public override void InvokeSkill()
    {
        Owner.Anim.Play("Rskill");
        Instantiate(Data.skillEffect[3], Owner.transform.position, Quaternion.identity);
    }
}
