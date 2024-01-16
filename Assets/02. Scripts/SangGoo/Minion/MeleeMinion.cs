using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class MeleeMinion : Minion
{
    public GameObject atkEffectObject;
    [SerializeField] MeleeMinionAttackEffectController atkEffectController;

    protected new void Start()
    {
        type = typeof(MeleeMinion);

        base.Start();
        // 체력, 공격력, 방어력, 마법저항력, 공격속도, 이동속도
        minionInfo = new MinionInfo(100, 10, 5, 5, 1.0f, 3.0f);
        atkEffectController = atkEffectObject.GetComponent<MeleeMinionAttackEffectController>();

        atkEffectController.SetOwner(this);
        PoolManager.instacne.CreatePool(atkEffectController.type);

        if(PoolManager.instacne.GetCount(atkEffectController.type) < 30)
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
        GameObject poolObj = PoolManager.instacne.Dequeue(atkEffectController.type);
        poolObj.SetActive(true);
        if(attackRangeDetect.targetCol != null)
            poolObj.transform.position = attackRangeDetect.targetCol.transform.position;

        target.Hit(Atk);
        attackDelayCo = null;
    }
}
