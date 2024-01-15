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
        if (owner.SkillList[0].IsCool)
        {
            skillSolts[0].skillCoolImg.gameObject.SetActive(true);
        }

    }

    public void InitSlot()
    {
        for (int i = 0; i < skillSolts.Length; i++)
        {
            skillSolts[i].skillImg.sprite = owner.SkillList[i].Data.skillImg;
        }
    }
}
