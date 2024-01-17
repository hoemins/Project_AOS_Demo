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
        // 체력, 공격력, 방어력, 마법저항력, 공격속도, 이동속도
        minionInfo = new MinionInfo(50, 20, 0, 0, 0.7f, 3.0f);

        atkEffectController = atkEffectObject.GetComponent<RangeMinionAttackEffectController>();

        PoolManager.instacne.CreatePool(atkEffectController.type);

        if (PoolManager.instacne.GetCount(atkEffectController.type) < 60)
        {
            for (int i = 0; i < 10; i++)
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

    public override void Attack()
    {
        animator.SetInteger("CurState", (int)State.Attack);
        base.Attack();
    }

    public override IEnumerator AttackDelayCo(IHitable target)
    {
        yield return new WaitForSeconds(AttackDelay);
        animator.SetTrigger("Attack");
        GameObject poolObj = PoolManager.instacne.Dequeue(atkEffectController.type);

        poolObj.transform.position = transform.position;
        if (poolObj.TryGetComponent<RangeMinionAttackEffectController>(out var controller))
        {
            controller.hitAction += () => { target.Hit(Atk); };
            if (attackRangeDetect.targetCol != null)
                controller.SetTarget(attackRangeDetect.targetCol.transform);
        }
        poolObj.SetActive(true);

        attackDelayCo = null;
    }
}
