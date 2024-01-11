using Hoemin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 해당 클래스의 멤버를 인스펙터에 노출시킴
[Serializable]
public class ChampionInfo
{
    [SerializeField] private string name;
    [SerializeField] private int level;
    [SerializeField] private Sprite profileImg;

    [Header("챔피언 기본 스탯")]
    [SerializeField] private int physicalAtk; // 공격력
    [SerializeField] private int abilityAtk; // 주문력
    [SerializeField] private int phsicalDef; // 방어력
    [SerializeField] private int magicalResistance; // 마법 저항력
    [SerializeField] private float physicalAtkDelay; // 공격 속도
    [SerializeField] private int abilityHaste; // 스킬 가속
    [SerializeField] private float moveSpeed; // 이동 속도
    [SerializeField] private float criticalChance; // 치명타 확률

    public string Name { get { return name; } }
    public int Level { get { return level; } set { level = (level >= 18) ? 18 : value; } }
    public int PhysicalAtk { get {  return physicalAtk; }}
    public int AbilityAtk { get { return abilityAtk; }}
    public int PhsicalDef { get { return phsicalDef; }}
    public int MagicalResistance { get { return magicalResistance; }}  
    public float PhysicalAtkDelay { get { return physicalAtkDelay; }}
    public int AbilityHaste { get { return abilityHaste; }}
    public float MoveSpeed { get {  return moveSpeed; } set { moveSpeed = value; } }
    public float CriticalChance { get { return criticalChance; }}
}

public enum CHAMPION_STATE
{
    IDLE, MOVE, ATTACK, STUN, SLOWDOWN, AIRBORNE, DIE
}

public class Champion : MonoBehaviour
{
    [SerializeField] ChampionInfo championinfo;
    [SerializeField] CHAMPION_STATE curState;
    ChampionMoveController moveController;
    StateMachine<Champion> stateMachine;

    public CHAMPION_STATE CurState { get { return curState; } set { curState = value; } } // 현재 상태 변수
    public ChampionMoveController MoveController { get { return moveController; } }
    public ChampionInfo ChampionInfo { get {  return championinfo; } }

    // 문제점 : Awake 함수 호출 순서 때문에 NullRef 에러 발생
    // 해결 : ProjectSetting -> Script Excution order 탭에서 호출 순서 커스텀
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
    /// 챔피언 스탯 초기화
    /// </summary>
    private void InitChampionInfo()
    {
        championinfo.Level = 1;
        MoveController.Agent.speed = championinfo.MoveSpeed;
    }

    /// <summary>
    /// 상태 머신 초기화
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
