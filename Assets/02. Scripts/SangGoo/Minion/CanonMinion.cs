using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMinion : Minion
{


    protected new void Start()
    {
        type = typeof(CanonMinion);

        base.Start();
        // 체력, 공격력, 방어력, 마법저항력, 공격속도, 이동속도
        minionInfo = new MinionInfo(300, 40, 10, 10, 1.0f, 3.0f);
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
