using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMinion : Minion
{
    protected new void Start()
    {
        type = typeof(MeleeMinion);

        base.Start();
        // ü��, ���ݷ�, ����, �������׷�, ���ݼӵ�, �̵��ӵ�
        minionInfo = new MinionInfo(100, 10, 5, 5, 1.0f, 3.0f);
    }

    protected override void IdleMove()
    {
        base.IdleMove();
        animator.SetInteger("CurState", (int)State.Move);
    }

    protected override void ChaseMove()
    {
        base.ChaseMove();
        animator.SetInteger("CurState", (int)State.Chase);
    }

    protected override void Attack()
    {
        base.Attack();
    }

    public override IEnumerator AttackDelayCo(IHitable target)
    {
        yield return new WaitForSeconds(AttackDelay);
        animator.SetInteger("CurState", (int)State.Attack);
        target.Hit(Atk);
        attackDelayCo = null;
    }
}
