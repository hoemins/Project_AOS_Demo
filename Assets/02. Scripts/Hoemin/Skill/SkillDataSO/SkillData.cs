using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SkillData : ScriptableObject
{
    public Sprite skillImg;
    public string skillName;
    public int level;
    public int requiredLevel;
    public int comsumeMP;
    public float coolTime;
    public GameObject[] skillEffect;
}
