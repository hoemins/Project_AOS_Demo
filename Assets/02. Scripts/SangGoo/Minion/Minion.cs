using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinionInfo
{
    private int hp;
    private int maxHp;

    private int physicalAtk; // ���ݷ�
    private int phsicalDef; // ����
    private int magicalResistance; // ���� ���׷�

    private float physicalAtkDelay; // ���� �ӵ�
    private float moveSpeed; // �̵� �ӵ�

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

        // ���� ��Ʈ
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


        // �߰� ��Ʈ
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

        // �̵� ��Ʈ
        minionBT.moveAction.action += () => { IdleMove(); return INode.State.Run; };
    }

    public virtual void IdleMove()
    {
        Debug.Log("�̵� ��");
    }

    public virtual void ChaseMove()
    {
        Debug.Log("�߰� ��");
    }

    public virtual void Attack()
    {
        Debug.Log("���� ��");
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
