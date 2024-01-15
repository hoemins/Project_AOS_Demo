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

public class Minion : MonoBehaviour
{
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
            if (attackRangeDetect.targetCol == null)
                attackRangeDetect.targetCol = attackRangeDetect.Colliders[0];
            else
            {
                if (attackRangeDetect.Colliders.Contains(attackRangeDetect.targetCol) == false)
                    attackRangeDetect.targetCol = attackRangeDetect.Colliders[0];
            }
            return INode.State.Success;
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
            if(chaseRangeDetect.targetCol == null)
                chaseRangeDetect.targetCol = chaseRangeDetect.Colliders[0];
            else
            {
                if(chaseRangeDetect.Colliders.Contains(chaseRangeDetect.targetCol) == false)
                    chaseRangeDetect.targetCol = chaseRangeDetect.Colliders[0];
            }
            return INode.State.Success;
        };

        minionBT.chaseAction.action += () => { ChaseMove(); return INode.State.Run; };

        // 이동 파트
        minionBT.moveAction.action += () => { IdleMove(); return INode.State.Run; };
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
        Debug.Log("공격");
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
