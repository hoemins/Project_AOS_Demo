using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Reflection;

public class Israel_QSkill : Skill
{
    SkillEffectCreator handler;
    MethodInfo createEffectMethodInfo = null;
    FieldInfo effectListInfo = null;
    private float skillRange = 10f;
    
    
    public float SkillRange { get; }
    

    public Israel_QSkill(Champion owner) : base(owner) 
    {
        SkillInit();
    }


    public override void SkillInit()
    {
        name = "Mystic arrow";
        level = 1;
        requiredLevel = 1;
        comsumeMP = 10;
        coolTime = 6f;

        Type type = typeof(SkillEffectCreator);
        handler = Owner.gameObject.GetComponent<SkillEffectCreator>();
        createEffectMethodInfo = type.GetMethod("CreateEffect");
        effectListInfo = type.GetField("effectList",BindingFlags.Public | BindingFlags.Instance);
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
            //Owner.ChampionStats.CurMp -= comsumeMP;
            //createEffectMethodInfo.Invoke(handler, new object[] { (int)BUTTON.Q_BTN });
            //IsCool = true;
            Debug.Log("이즈 Q 스킬 발동");
        }
    }
}
