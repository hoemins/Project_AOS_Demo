using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMinion : Minion
{
    protected new void Start()
    {
        type = typeof(CanonMinion);

        base.Start();
        // ü��, ���ݷ�, ����, �������׷�, ���ݼӵ�, �̵��ӵ�
        minionInfo = new MinionInfo(300, 40, 10, 10, 1.0f, 3.0f);
    }

    protected override void IdleMove()
    {
        base.IdleMove();
    }

    protected override void ChaseMove()
    {
        base.ChaseMove();
    }

    protected override void Attack()
    {
        base.Attack();
    }
}
