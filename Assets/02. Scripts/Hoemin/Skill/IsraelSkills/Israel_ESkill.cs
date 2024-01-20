using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Israel_ESkill : Skill
{
    
    [SerializeField] private float range = 8f;
    [SerializeField] private GameObject effect;
    Ray ray;
    RaycastHit hit;
    private void Update()
    {
       
        ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        
        
        if (Physics.Raycast(ray, out hit))
        {
            // 이 비어있는 조건문이 있어야 올바르게 작동
            // 이유..? 모르겠음
        }
    }


    public override void InvokeSkill()
    {
        if (IsCool)
        {
            return;
        }

        if (Vector3.Distance(Owner.transform.position, hit.transform.position) > range)
            return;

        

        IsCool = true;
        Owner.ChampionStats.CurMp -= Data.comsumeMP;
        Owner.Anim.Play("Eskill");

        if (Owner.DetectComponent.IsDetected == true)
        {
            effect.SetActive(true);
        }
        

        Owner.transform.position = hit.point;

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
        //Owner.SkillList[2].gameObject.GetComponent<SkillAttack>().Damage += 30;
        Owner.SkillList[2].Data.coolTime *= 0.7f;
    }
}
