using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Israel_ESkill : Skill
{

    private float skillRange = 8f;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
    }


    public override void InvokeSkill()
    {
        Owner.Anim.Play("Eskill");
        Instantiate(Data.skillEffect[2], Owner.transform.position, Quaternion.identity);
        Owner.transform.position = Input.mousePosition;
    }
}
