using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Israel_WSkill : Skill
{

    public override void InvokeSkill()
    {
        if (IsCool)
        {
            Debug.Log("ÄðÅ¸ÀÓÁß");
            return;
        }
        Owner.Anim.Play("Wskill");
        Instantiate(Data.skillEffect[0], Owner.transform.position, Quaternion.identity);
        IsCool = true;
        StartCoroutine(CoolTimeCor());
    }

    IEnumerator CoolTimeCor()
    {
        float curTime = 0;
        while (IsCool)
        {
            curTime += Time.deltaTime;
            if (curTime >= Data.coolTime)
            {
                if (IsCool)
                {
                    IsCool = false;
                    curTime = 0;
                }
            }
            yield return null;
        }
    }
}

