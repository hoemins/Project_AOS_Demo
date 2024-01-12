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

    public string Name { get { return name; } set { name = value; } }
    public int Level { get { return level; } set { level = (level >= 18) ? 18 : value; } }
    public int PhysicalAtk { get {  return physicalAtk; } set { physicalAtk = value; } }
    public int AbilityAtk { get { return abilityAtk; } set { abilityAtk = value; } }
    public int PhsicalDef { get { return phsicalDef; } set { phsicalDef = value; } }
    public int MagicalResistance { get { return magicalResistance; } set { magicalResistance = value;  } }  
    public float PhysicalAtkDelay { get { return physicalAtkDelay; } set { physicalAtkDelay = value; } }
    public int AbilityHaste { get { return abilityHaste; } set { abilityHaste = value; } }
    public float MoveSpeed { get {  return moveSpeed; } set { moveSpeed = value; } }
    public float CriticalChance { get { return criticalChance; } set { criticalChance = value; } }
}

[Serializable]
public class ChampionStats
{
    [SerializeField] private int curHp;
    [SerializeField] private int maxHp;
    [SerializeField] private int curMp;
    [SerializeField] private int maxMp;

    public int MaxHp { get { return maxHp; } set { maxHp = value; } }
    public int MaxMp { get {  return maxMp; } set { maxMp = value; } }
    public int CurHp 
    { 
        get { return curHp; } 
        set 
        {
            if(curHp <= 0 ) curHp = 0;
            curHp = value; 
        } 
    }
    public int CurMp 
    { 
        get  { return curMp; }
        set
        {
            if (curMp <= 0 ) curMp = 0;
            curMp = value;
        }
    }
}


public enum CHAMPION_STATE
{
    IDLE, MOVE, ATTACK, STUN, SLOWDOWN, AIRBORNE, DIE
}

public abstract class Champion : MonoBehaviour
{
    [SerializeField] protected ChampionInfo championinfo;
    [SerializeField] protected ChampionStats championStats;
    [SerializeField] protected CHAMPION_STATE curState;
    [SerializeField] protected ChampionMoveController moveController;
    [SerializeField] List<Skill> skillList;
    private StateMachine<Champion> stateMachine;
    private const int skillCount = 4;
    Action onDie;

    //=============================������Ƽ======================================//
    public CHAMPION_STATE CurState { get { return curState; } set { curState = value; } }
    public ChampionMoveController MoveController { get { return moveController; } }
    public ChampionInfo ChampionInfo { get {  return championinfo; } }
    public ChampionStats ChampionStats { get { return championStats; } }
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
    /// è�Ǿ� �⺻ ���� �ʱ�ȭ
    /// </summary>
    public abstract void InitChampionInfo();

    public abstract void InitChampionStats();

    public abstract void SetSkill();
        

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
