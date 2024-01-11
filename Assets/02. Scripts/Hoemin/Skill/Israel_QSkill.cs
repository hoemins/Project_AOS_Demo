using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Reflection;

public class Israel_QSkill : WaitSkill
{
    SkillEffectHandler handler;
    Vector3 firePos;
    public Israel_QSkill(Champion owner) : base(owner) { }


    public override void SkillInit()
    {
        name = "Mystic arrow";
        level = 1;
        requiredLevel = 1;
        comsumeMP = 10;
        coolTime = 6f;
        firePos = Owner.gameObject.transform.position + Vector3.up; // offset ∏¬√Á¡÷±‚
    }
    public override void Fire()
    {
        handler = Owner.gameObject.GetComponent<SkillEffectHandler>();

        Type type = typeof(SkillEffectHandler);
        MethodInfo methodInfo = type.GetMethod("CreateEffect");
        FieldInfo fieldInfo = type.GetField("effectList");
        fieldInfo.GetValue(handler);
        methodInfo.Invoke(handler, null);
       
    }
}
