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
    [SerializeField] private uint phsicalDef; // 방어력
    [SerializeField] private uint magicalResistance; // 마법 저항력
    [SerializeField] private uint abilityHaste; // 스킬 가속
    [SerializeField] private float moveSpeed; // 이동 속도
    [SerializeField] private float criticalChance; // 치명타 확률

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
