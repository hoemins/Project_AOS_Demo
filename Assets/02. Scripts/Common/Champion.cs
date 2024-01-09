using Hoemin;
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
    public float MoveSpeed { get {  return moveSpeed; } set { moveSpeed = value; } }
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
    [SerializeField] CHAMPION_STATE curState;

    /// <summary>
    /// �ִϸ��̼ǰ� ���� ��ȯ�� FSM
    /// </summary>
    StateMachine<Champion> stateMachine;

    private ChampionMoveController moveController;
    
    public CHAMPION_STATE CurState { get { return curState; } set { curState = value; } } // ���� ���� ����
    public ChampionMoveController MoveController { get { return moveController; } }

    // ������ : Awake �Լ� ȣ�� ���� ������ NullRef ���� �߻�
    // �ذ� : ProjectSetting -> Script Excution order �ǿ��� ȣ�� ���� Ŀ����
    private void Awake()
    {
        championinfo = new ChampionInfo();
        championinfo.MoveSpeed = 5f;
        moveController = GetComponent<ChampionMoveController>();
        InitChampionInfo();
    }

    private void Start()
    {
        InitState();
    }
    /// <summary>
    /// è�Ǿ� ���� �ʱ�ȭ
    /// </summary>
    private void InitChampionInfo()
    {
        championinfo.Level = 1;
        MoveController.Agent.speed = championinfo.MoveSpeed;
    }

    /// <summary>
    /// ���� �ӽ� �ʱ�ȭ
    /// </summary>
    private void InitState()
    {
        stateMachine = new StateMachine<Champion>(this);
        stateMachine.AddState((int)CHAMPION_STATE.IDLE, new ChampionIdleState());
        stateMachine.AddState((int)CHAMPION_STATE.MOVE, new ChampionMoveState());
        stateMachine.AddState((int)CHAMPION_STATE.ATTACK, new ChampionAttackState());
        stateMachine.AddState((int)CHAMPION_STATE.STUN, new ChampionStunState());
        stateMachine.AddState((int)CHAMPION_STATE.SLOWDOWN, new ChampionSlowDownState());
        stateMachine.AddState((int)CHAMPION_STATE.AIRBORNE, new ChampionAirborneState());
        stateMachine.SetState((int)CHAMPION_STATE.IDLE);
        curState = CHAMPION_STATE.IDLE;
    }

    public void Update()
    {
        stateMachine.Update();
    }
}
