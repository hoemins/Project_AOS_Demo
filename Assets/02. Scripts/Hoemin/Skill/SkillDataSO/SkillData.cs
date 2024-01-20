using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SKILLTYPE
{
    DEFAULT, BUFF, 
}

[CreateAssetMenu]
public class SkillData : ScriptableObject, ISerializationCallbackReceiver
{
    public Sprite skillImg;
    public string skillName;
    public int level;
    public int requiredLevel;
    public int comsumeMP;
    public float coolTime;
    

    public void OnAfterDeserialize()
    {
        level = 1;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
