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
    [SerializeField] private uint phsicalDef; // ����
    [SerializeField] private uint magicalResistance; // ���� ���׷�
    [SerializeField] private uint abilityHaste; // ��ų ����
    [SerializeField] private float moveSpeed; // �̵� �ӵ�
    [SerializeField] private float criticalChance; // ġ��Ÿ Ȯ��

    public string Name { get { return name; } }
    public uint Level { get { return level; } set { level = (level >= 18) ? 18 : value; } }
    public uint PhysicalAtk { get {  return physicalAtk; }}
    public uint AbilityAtk { get { return abilityAtk; }}
    public uint PhsicalDef { get { return phsicalDef; }}
    public uint MagicalResistance { get { return magicalResistance; }}  
    public float MoveSpeed { get {  return moveSpeed; }}
    public float CriticalChance { get { return criticalChance; }}
    public uint AbilityHaste { get { return abilityHaste; }}
}

public enum CHAMPION_STATE
{
    IDLE, MOVE, ATTACK, STUN, SLOWDOWN, AIRBORNE, DIE
}

public class Champion : MonoBehaviour
{
    [SerializeField] ChampionInfo championinfo;
    StateMachine<Champion> stateMachine;

    private void Awake()
    {
        StateInit();
    }

    private void StateInit()
    {
        stateMachine = new StateMachine<Champion>(this);
        stateMachine.AddState((int)CHAMPION_STATE.IDLE, new ChampionIdleState());
        stateMachine.AddState((int)CHAMPION_STATE.MOVE, new ChampionMoveState());
        stateMachine.AddState((int)CHAMPION_STATE.ATTACK, new ChampionAttackState());
        stateMachine.AddState((int)CHAMPION_STATE.STUN, new ChampionStunState());
        stateMachine.AddState((int)CHAMPION_STATE.SLOWDOWN, new ChampionSlowDownState());
        stateMachine.AddState((int)CHAMPION_STATE.AIRBORNE, new ChampionAirborneState());
        stateMachine.SetState((int)CHAMPION_STATE.IDLE);
    }

    public void Update()
    {
        stateMachine.Update();
    }
}
