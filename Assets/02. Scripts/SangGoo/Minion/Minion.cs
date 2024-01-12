using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected MinionInfo minionInfo;

    MinionBT minionBT;

    [SerializeField] DetectComponent attackRangeDetect;
    [SerializeField] DetectComponent chaseRangeDetect;

    private void Start()
    {
        minionBT = GetComponent<MinionBT>();

        // 공격 파트
        minionBT.targetInAttackRange.action += () =>
        {
            if (attackRangeDetect.IsDetected)
                return INode.State.Success;
            return INode.State.Fail;
        };
        minionBT.attackAction.action += () => { Attack(); return INode.State.Run; };


        // 추격 파트
        minionBT.targetInChaseRange.action += () =>
        {
            if (chaseRangeDetect.IsDetected)
                return INode.State.Success;
            return INode.State.Fail;
        };
        minionBT.chaseAction.action += () => { ChaseMove(); return INode.State.Run; };

        // 이동 파트
        minionBT.moveAction.action += () => { IdleMove(); return INode.State.Run; };
    }

    public virtual void IdleMove()
    {
        Debug.Log("이동 중");
    }

    public virtual void ChaseMove()
    {
        Debug.Log("추격 중");
    }

    public virtual void Attack()
    {
        Debug.Log("공격 중");
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
