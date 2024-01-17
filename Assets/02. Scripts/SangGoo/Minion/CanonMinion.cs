using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMinion : Minion
{
    public GameObject atkEffectObject;
    [SerializeField] CanonMinionAttackEffectController atkEffectController;

    protected new void Start()
    {
        type = typeof(CanonMinion);

        base.Start();
        // ü��, ���ݷ�, ����, �������׷�, ���ݼӵ�, �̵��ӵ�
        minionInfo = new MinionInfo(300, 40, 10, 10, 1.0f, 3.0f);
        
        atkEffectController = atkEffectObject.GetComponent<CanonMinionAttackEffectController>();

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
        if (poolObj.TryGetComponent<CanonMinionAttackEffectController>(out var controller))
        {
            controller.hitAction += () => { target.Hit(Atk); };
            if (attackRangeDetect.targetCol != null)
                controller.SetTarget(attackRangeDetect.targetCol.transform);
        }
        poolObj.SetActive(true);

        attackDelayCo = null;
    }
}
