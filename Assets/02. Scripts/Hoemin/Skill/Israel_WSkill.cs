using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;

public class Israel_WSkill : WaitSkill
{
    SkillEffectCreator handler;
    MethodInfo createEffectMethodInfo = null;
    FieldInfo effectListInfo = null;
    private float skillRange = 10f;


    public float SkillRange { get; }
    public Israel_WSkill(Champion owner) : base(owner)
    {
        SkillInit();
    }
    public override void SkillInit()
    {
        name = "Flow of essence";
        level = 1;
        requiredLevel = 1;
        comsumeMP = 20;
        coolTime = 10f;

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
            Debug.Log("스킬을 사용할 수 없습니다.");
            return;
        }
        else
        {
            Owner.ChampionStats.CurMp -= comsumeMP;
            createEffectMethodInfo.Invoke(handler, new object[] { (int)BUTTON.W_BTN });
            IsCool = true;
        }
    }

    
}

