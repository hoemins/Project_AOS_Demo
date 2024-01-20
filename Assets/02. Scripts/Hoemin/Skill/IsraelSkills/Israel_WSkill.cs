using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Israel_WSkill : Skill
{
    [SerializeField] private GameObject effect;

    public override void InvokeSkill()
    {
        if (IsCool)
        {
            Debug.Log("��Ÿ����");
            return;
        }

        IsCool = true;
        Owner.ChampionStats.CurMp -= Data.comsumeMP;
        Owner.Anim.Play("Wskill");
        effect.SetActive(true);
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
        if (Owner.SkillList[1].Data.level > 5) return;
        Owner.SkillList[1].Data.level++;
        //Owner.SkillList[1].gameObject.GetComponent<SkillAttack>().Damage += 30;
        Owner.SkillList[1].Data.coolTime *= 0.7f;
    }
}

