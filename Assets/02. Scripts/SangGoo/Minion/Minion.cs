using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MinionInfo
{
    private int hp;
    private int maxHp;

    private int physicalAtk; // 공격력
    private int phsicalDef; // 방어력
    private int magicalResistance; // 마법 저항력

    private float physicalAtkDelay; // 공격 속도
    private float moveSpeed; // 이동 속도

    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
        }
    }
    public int MaxHp => maxHp;
    public int PhysicalAtk => physicalAtk;
    public float PhysicalAtkDelay => physicalAtkDelay;

    public MinionInfo(int hp, int physicalAtk,int phsicalDef, int magicalRsistance, float physicalAtkDelay, float moveSpeed)
    {
        this.maxHp = hp;
        this.hp = hp;
        this.physicalAtk = physicalAtk;
        this.phsicalDef = phsicalDef;
        this.magicalResistance = magicalRsistance;
        this.physicalAtkDelay = physicalAtkDelay;
        this.moveSpeed = moveSpeed;
    }
}

public class Minion : MonoBehaviour, IHitable
{
    protected enum State
    {
        Idle,
        Move,
        Chase,
        Attack
    }

    public int Hp
    {
        get => minionInfo.Hp;

        set
        {
            minionInfo.Hp = value;
            if (minionInfo.Hp > minionInfo.MaxHp)
                minionInfo.Hp = minionInfo.MaxHp;

            if(minionInfo.Hp <= 0)
            {
                OnDie();
                return;
            }
        }
    }
    public Action OnDie;
    
    public int Atk
    {
        get => minionInfo.PhysicalAtk;
    }

    public float AttackDelay
    {
        get => minionInfo.PhysicalAtkDelay;
    }
    protected IEnumerator attackDelayCo;

    public bool IsDie
    {
        get => isDie;
        private set
        {
            isDie = value;
        }
    }
    private bool isDie;

    public Type type;
    public Transform goalPoint;

    protected MinionInfo minionInfo;
    protected MinionBT minionBT;
    protected Animator animator;
    [SerializeField] protected NavMeshAgent navMeshAgent;

    [SerializeField] DetectComponent attackRangeDetect;
    [SerializeField] DetectComponent chaseRangeDetect;

    protected void Start()
    {
        minionBT = GetComponent<MinionBT>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        // 공격 파트
        minionBT.targetInAttackRange.action += () =>
        {
            if (attackRangeDetect.IsDetected)
                return INode.State.Success;
            else
                attackRangeDetect.targetCol = null;

            return INode.State.Fail;
        };

        minionBT.targetingToAttack.action += () =>
        {
            SetTarget(attackRangeDetect);
            return attackRangeDetect.targetCol == null ? INode.State.Fail : INode.State.Success;
        };

        minionBT.attackAction.action += () => { Attack(); return INode.State.Run; };

        // 추격 파트
        minionBT.targetInChaseRange.action += () =>
        {
            if (chaseRangeDetect.IsDetected)
                return INode.State.Success;
            else
                chaseRangeDetect.targetCol = null;

            return INode.State.Fail;
        };

        minionBT.targetingToChase.action += () =>
        {
            SetTarget(chaseRangeDetect);
            return chaseRangeDetect.targetCol == null ? INode.State.Fail : INode.State.Success;
        };

        minionBT.chaseAction.action += () => { ChaseMove(); return INode.State.Run; };

        // 이동 파트
        minionBT.moveAction.action += () => { IdleMove(); return INode.State.Run; };

        // Die 이벤트
        OnDie += () => { IsDie = true; };
        OnDie += () => { attackRangeDetect.targetCol = null; };
        OnDie += () => { chaseRangeDetect.targetCol = null; };
        OnDie += () => { PoolManager.instacne.ReturnPool(type, gameObject); };
    }

    private void OnEnable()
    {
        IsDie = false;
    }

    protected virtual void IdleMove()
    {
        navMeshAgent.SetDestination(goalPoint.position);
    }

    protected virtual void ChaseMove()
    {
        navMeshAgent.SetDestination(chaseRangeDetect.targetCol.transform.position);
    }

    protected virtual void Attack()
    {
        navMeshAgent.ResetPath();
        if(attackRangeDetect.targetCol.TryGetComponent<IHitable>(out var target))
        {
            if (attackDelayCo == null)
            {
                attackDelayCo = AttackDelayCo(target);
                StartCoroutine(attackDelayCo);
            }
        }
    }


    public virtual IEnumerator AttackDelayCo(IHitable target)
    {
        yield return new WaitForSeconds(AttackDelay);
        target.Hit(Atk);
        attackDelayCo = null;
    }

    public void SetTarget(DetectComponent detectComponent)
    {
        if (detectComponent.targetCol == null)
        {
            foreach (Collider collider in detectComponent.Colliders)
            {
                if (gameObject.tag == collider.tag)
                    continue;

                detectComponent.targetCol = collider;
            }
        }
        else
        {
            if(detectComponent.targetCol.TryGetComponent<Minion>(out var target))
            {
                if(target.IsDie)
                {
                    detectComponent.targetCol = null;
                    SetTarget(detectComponent);
                }
            }

            if (detectComponent.Colliders.Contains(detectComponent.targetCol) == false)
            {
                foreach (Collider collider in detectComponent.Colliders)
                {
                    if (gameObject.tag == collider.tag)
                        continue;

                    detectComponent.targetCol = collider;
                }
            }
        }

    }

    public void Hit(int value)
    {
        Hp -= value;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (chaseRangeDetect != null)
            Gizmos.DrawWireSphere(transform.position, chaseRangeDetect.DetectRange);

        Gizmos.color = Color.red;
        if (attackRangeDetect != null)
            Gizmos.DrawWireSphere(transform.position, attackRangeDetect.DetectRange);
    }
}
