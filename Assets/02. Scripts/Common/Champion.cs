using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ش� Ŭ������ ����� �ν����Ϳ� �����Ŵ
[Serializable]
public class ChampionInfo
{
    [SerializeField] private string name;
    [SerializeField] private uint level;
    [SerializeField] private Sprite profileImg;

    [Header("è�Ǿ� �⺻ ����")]
    [SerializeField] private uint physicalAtk; // ���ݷ�
    [SerializeField] private uint abilityAtk; // �ֹ���
    [SerializeField] private uint abilityHaste; // ��ų ����
    [SerializeField] private float moveSpeed; // �̵� �ӵ�
    [SerializeField] private float criticalChance; // ġ��Ÿ Ȯ��

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
