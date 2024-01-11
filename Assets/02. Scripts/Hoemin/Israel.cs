using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Israel : Champion
{
    public override void Awake()
    {
        base.Awake();
        
    }
    private void Start()
    {
        SetSkill();
    }

    public void SetSkill()
    {
        SkillList.Add(new Israel_QSkill(this));
        SkillList.Add(new Israel_WSkill(this));
    }
}
