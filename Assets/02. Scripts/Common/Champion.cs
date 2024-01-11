using Hoemin;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// �ش� Ŭ������ ����� �ν����Ϳ� �����Ŵ
[Serializable]
public class ChampionInfo
{
    [SerializeField] private string name;
    [SerializeField] private int level;
    [SerializeField] private Sprite profileImg;

    [Header("è�Ǿ� �⺻ ����")]
    [SerializeField] private int physicalAtk; // ���ݷ�
    [SerializeField] private int abilityAtk; // �ֹ���
    [SerializeField] private int phsicalDef; // ����
    [SerializeField] private int magicalResistance; // ���� ���׷�
    [SerializeField] private float physicalAtkDelay; // ���� �ӵ�
    [SerializeField] private int abilityHaste; // ��ų ����
    [SerializeField] private float moveSpeed; // �̵� �ӵ�
    [SerializeField] private float criticalChance; // ġ��Ÿ Ȯ��

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

public abstract class Champion : MonoBehaviour
{
    [SerializeField] protected ChampionInfo championinfo;
    [SerializeField] protected CHAMPION_STATE curState;
    [SerializeField] protected ChampionMoveController moveController;
    [SerializeField] List<Skill> skillList;
    private StateMachine<Champion> stateMachine;
    private const int skillCount = 4;

    //=============================������Ƽ======================================//
    public CHAMPION_STATE CurState { get { return curState; } set { curState = value; } } // ���� ���� ����
    public ChampionMoveController MoveController { get { return moveController; } }
    public ChampionInfo ChampionInfo { get {  return championinfo; } }
    public List<Skill> SkillList { get {  return skillList; } }
    //===========================================================================//

    // ������ : Awake �Լ� ȣ�� ���� ������ NullRef ���� �߻�
    // �ذ� : ProjectSetting -> Script Excution order �ǿ��� ȣ�� ���� Ŀ����
    public virtual void Awake()
    {
        skillList = new List<Skill>(skillCount);
        InitState();
        InitChampionInfo();
    }



    /// <summary>
    /// è�Ǿ� ���� �ʱ�ȭ
    /// </summary>
    private void InitChampionInfo()
    {
        championinfo.Level = 1;
        championinfo.MoveSpeed = 4f;
        //MoveController.Agent.speed = championinfo.MoveSpeed;
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
