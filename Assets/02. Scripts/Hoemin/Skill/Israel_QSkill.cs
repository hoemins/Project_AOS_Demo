using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Israel_QSkill : Skill
{


    public override void InvokeSkill()
    {
        if (IsCool)
        {
            Debug.Log("ÄðÅ¸ÀÓÁß");
            return;
        }
        
        IsCool = true;
        Owner.ChampionStats.CurMp -= Data.comsumeMP;
        Owner.Anim.Play("Qskill");
        Instantiate(Data.skillEffect[0], Owner.transform.position + Vector3.forward * 0.5f, Quaternion.identity);
        StartCoroutine(DelayCor());
        StartCoroutine(CoolTimeCor());
    }

    IEnumerator DelayCor()
    {
        Owner.MoveController.Agent.isStopped = true;
        Owner.MoveController.Agent.ResetPath();
        yield return new WaitForSeconds(0.5f);
        Owner.MoveController.Agent.isStopped = false;

    }
    public IEnumerator CoolTimeCor()
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
