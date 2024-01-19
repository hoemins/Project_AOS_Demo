using Hoemin;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public string Name { get { return name; } set { name = value; } }
    public int Level { get { return level; } set { level = (level >= 18) ? 18 : value; } }

    public Sprite ProfileImg { get { return profileImg; } }
    
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
    [SerializeField] protected ChampionAttackController attackController;
    [SerializeField] protected List<Skill> skillList;
    [SerializeField] private int curExp;
    [SerializeField] private int aimExp;
    public int skillPoint = 1;
    private Animator anim;
    private StateMachine<Champion> stateMachine;
    public Action onLevelup;
    public Action onDie;
    //=============================프로퍼티======================================//
    public CHAMPION_STATE CurState { get { return curState; } set { curState = value; } }
    public ChampionMoveController MoveController { get { return moveController; } }
    public ChampionAttackController AttackController { get { return attackController; } }
    public ChampionInfo ChampionInfo { get {  return championinfo; } }
    public ChampionStats ChampionStats { get { return championStats; } }
    public List<Skill> SkillList { get {  return skillList; } }
    public Animator Anim { get { return anim; } }
    public int CurExp 
    { 
        get { return curExp; } 
        set 
        { 
            if(curExp >= AimExp)
            {
                onLevelup();
            }
            curExp = value;
        } 
    }
    public int AimExp 
    { 
        get { return aimExp; } 
        set 
        {
            aimExp = value;
        } 
    }
    //===========================================================================//


    // 문제점 : Awake 함수 호출 순서 때문에 NullRef 에러 발생
    // 해결 : ProjectSetting -> Script Excution order 탭에서 호출 순서 커스텀
    public virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        InitState();
        InitChampionInfo();
        
    }
    private void Start()
    {
        onLevelup += LevelUp;
    }

    /// <summary>
    /// 챔피언 기본 정보 초기화
    /// </summary>
    public abstract void InitChampionInfo();

    public abstract void InitChampionStats();


    public abstract Skill GetSkill(int index);

    public void LevelUp()
    {
        championinfo.Level++;
        skillPoint++;
        CurExp = 0;
        AimExp = championinfo.Level * 200;
        Debug.Log("렙업");
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
