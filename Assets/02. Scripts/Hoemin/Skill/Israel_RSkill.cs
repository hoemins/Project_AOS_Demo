using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;

public class Israel_RSkill : WaitSkill
{
    SkillEffectCreator handler;
    MethodInfo createEffectMethodInfo = null;
    FieldInfo effectListInfo = null;
    private float skillRange = Mathf.Infinity;

    public Israel_RSkill(Champion owner) : base(owner)
    {
        SkillInit();
    }


    public override void SkillInit()
    {
        name = "Aimed strike";
        level = 1;
        requiredLevel = 6;
        comsumeMP = 120;
        coolTime = 60f;

        Type type = typeof(SkillEffectCreator);
        handler = Owner.gameObject.GetComponent<SkillEffectCreator>();
        createEffectMethodInfo = type.GetMethod("CreateEffect");
        effectListInfo = type.GetField("effectList", BindingFlags.Public | BindingFlags.Instance);
        effectListInfo.GetValue(handler);
    }

    public override void Fire()
    {
        if (Owner.ChampionStats.CurMp < comsumeMP || IsCool)
        {
            Debug.Log("��ų�� ����� �� �����ϴ�.");
            return;
        }
        else
        {
            Owner.ChampionStats.CurMp -= comsumeMP;
            createEffectMethodInfo.Invoke(handler, new object[] { (int)BUTTON.R_BTN });
            IsCool = true;
        }
    }
}
