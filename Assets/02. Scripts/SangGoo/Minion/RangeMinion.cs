using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMinion : Minion
{
    public GameObject atkEffectObject;
    [SerializeField] RangeMinionAttackEffectController atkEffectController;

    protected new void Start()
    {
        type = typeof(RangeMinion);

        base.Start();
        // ü��, ���ݷ�, ����, �������׷�, ���ݼӵ�, �̵��ӵ�
        minionInfo = new MinionInfo(50, 20, 0, 0, 0.7f, 3.0f);

        atkEffectController = atkEffectObject.GetComponent<RangeMinionAttackEffectController>();

        atkEffectController.SetOwner(this);
        PoolManager.instacne.CreatePool(atkEffectController.type);

        if (PoolManager.instacne.GetCount(atkEffectController.type) < 30)
        {
            for (int i = 0; i < 5; i++)
                PoolManager.instacne.Enqueue(atkEffectController.type, atkEffectObject);
        }
    }

    protected override void IdleMove()
    {
        animator.SetInteger("CurState", (int)State.Move);
        base.IdleMove();
    }

    protected override void ChaseMove()
    {
        animator.SetInteger("CurState", (int)State.Chase);
        base.ChaseMove();
    }

    protected override void Attack()
    {
        animator.SetInteger("CurState", (int)State.Attack);
        base.Attack();
    }

    public override IEnumerator AttackDelayCo(IHitable target)
    {
        yield return new WaitForSeconds(AttackDelay);
        animator.SetTrigger("Attack");
        target.Hit(Atk);
        attackDelayCo = null;
    }
}
