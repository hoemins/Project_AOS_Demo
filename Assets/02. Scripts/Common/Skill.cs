using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour 
{
    [SerializeField] SkillData data;
    
    private bool isCool;
    private Champion owner;

    public SkillData Data { get { return data; } }
    public Champion Owner { get { return owner; } }
    public bool IsCool { get { return isCool; } set { isCool = value; } }

    private void Awake()
    {
        owner = GetComponentInParent<Champion>();
    }

    public abstract void InvokeSkill();
    

}


