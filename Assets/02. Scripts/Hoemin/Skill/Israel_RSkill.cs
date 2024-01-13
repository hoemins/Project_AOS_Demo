using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;

public class Israel_RSkill : Skill
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

    public override void InvokeSkill()
    {
        if (Owner.ChampionStats.CurMp < comsumeMP || IsCool)
        {
            Debug.Log("스킬을 사용할 수 없습니다.");
            return;
        }
        else
        {
            Owner.ChampionStats.CurMp -= comsumeMP;
            //createEffectMethodInfo.Invoke(handler, new object[] { (int)BUTTON.R_BTN });
            IsCool = true;
        }
    }
}
