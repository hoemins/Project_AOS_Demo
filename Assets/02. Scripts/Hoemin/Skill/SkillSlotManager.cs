using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlotManager : MonoBehaviour
{
    [SerializeField] Champion owner;
    [SerializeField] SkillSlot[] skillSolts;

    private void Start()
    {
        InitSlot();
    }

    private void Update()
    {
        TrySkillInvoke(0);
        TrySkillInvoke(1);
        TrySkillInvoke(2);
        TrySkillInvoke(3);

    }

    public void InitSlot()
    {
        for (int i = 0; i < skillSolts.Length ; i++)
        {
            skillSolts[i].skillImg.sprite = owner.SkillList[i].Data.skillImg;
            skillSolts[i].skillCoolImg.sprite = owner.SkillList[i].Data.skillImg;
            skillSolts[i].skillCoolImg.gameObject.SetActive(false);
            skillSolts[i].coolTimeText.gameObject.SetActive(false);
            skillSolts[i].skillCoolImg.fillAmount = 0;
            skillSolts[i].coolTimeText.text = owner.SkillList[i].Data.coolTime.ToString();
        }
    }

    public void TrySkillInvoke(int index)
    {
        if (owner.SkillList[index].IsCool)
        {
            skillSolts[index].skillCoolImg.gameObject.SetActive(true);
            skillSolts[index].coolTimeText.gameObject.SetActive(true);
            StartCoroutine(ShowCoolImgAndTextCor(index));
        }
        else
        {
            skillSolts[index].skillCoolImg.gameObject.SetActive(false);
            skillSolts[index].coolTimeText.gameObject.SetActive(false);
        }
    }

    IEnumerator ShowCoolImgAndTextCor(int index)
    {
        float curCoolTime = owner.SkillList[index].Data.coolTime;
        float tick = 1f / curCoolTime;
        float t = 0;

        skillSolts[index].skillCoolImg.fillAmount = 1;

        while (skillSolts[index].skillCoolImg.fillAmount >0)
        {
            skillSolts[index].skillCoolImg.fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            curCoolTime -= Time.deltaTime;
            skillSolts[index].coolTimeText.text = ((int)curCoolTime).ToString();
            

            yield return null;  
        }
    }
}
