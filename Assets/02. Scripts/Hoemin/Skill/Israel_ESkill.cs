using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Israel_ESkill : Skill
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
        Owner.Anim.Play("Eskill");
        Instantiate(Data.skillEffect[0], Owner.transform.position, Quaternion.identity);
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

    public override void LevelUp()
    {
        if (Owner.SkillList[2].Data.level > 5) return;
        Owner.SkillList[2].Data.level++;
        Owner.SkillList[2].gameObject.GetComponent<SkillAttack>().Damage += 30;
        Owner.SkillList[2].Data.coolTime *= 0.7f;
    }
}
