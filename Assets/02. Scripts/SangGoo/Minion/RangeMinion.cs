using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMinion : Minion
{
    protected new void Start()
    {
        type = typeof(RangeMinion);

        base.Start();
        // 체력, 공격력, 방어력, 마법저항력, 공격속도, 이동속도
        minionInfo = new MinionInfo(50, 20, 0, 0, 1.0f, 3.0f);
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
