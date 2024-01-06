using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 해당 클래스의 멤버를 인스펙터에 노출시킴
[Serializable]
public class ChampionInfo
{
    [SerializeField] private string name;
    [SerializeField] private uint level;
    [SerializeField] private Sprite profileImg;

    [Header("챔피언 기본 스탯")]
    [SerializeField] private uint physicalAtk; // 공격력
    [SerializeField] private uint abilityAtk; // 주문력
    [SerializeField] private uint abilityHaste; // 스킬 가속
    [SerializeField] private float moveSpeed; // 이동 속도
    [SerializeField] private float criticalChance; // 치명타 확률

    public string Name { get { return name; } }
    public uint Level { get { return level; } set { level = (level >= 18) ? 18 : value; } }
    public uint PhysicalAtk { get {  return physicalAtk; }}
    public uint AbilityAtk { get { return abilityAtk; }}
    public float MoveSpeed { get {  return moveSpeed; }}
    public float CriticalChance { get { return criticalChance; }}
    public uint AbilityHaste { get { return abilityHaste; }}
}


public class Champion : MonoBehaviour
{
    [SerializeField] ChampionInfo championinfo;
}
