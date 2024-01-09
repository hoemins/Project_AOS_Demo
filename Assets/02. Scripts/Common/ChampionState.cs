using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionIdleState : ChampionState
{
    public override void Enter()
    {
        champion.CurState = CHAMPION_STATE.IDLE;
    }

    public override void Update()
    {
        if(champion.MoveController.Agent.velocity != Vector3.zero)
            sm.SetState((int)CHAMPION_STATE.MOVE);
    }

    public override void Exit()
    {
       
    }
}

public class ChampionMoveState : ChampionState
{
    public override void Enter()
    {
        champion.CurState = CHAMPION_STATE.MOVE;
    }

    public override void Update()
    {
        if (champion.MoveController.Agent.velocity == Vector3.zero)
            sm.SetState((int)CHAMPION_STATE.IDLE);
    }


    public override void Exit()
    {

    }
}

public class ChampionAttackState : ChampionState
{
    public override void Enter()
    {
        champion.CurState = CHAMPION_STATE.ATTACK;
    }

    public override void Update()
    {

    }


    public override void Exit()
    {

    }
}

public class ChampionStunState : ChampionState
{
    public override void Enter()
    {
        champion.CurState = CHAMPION_STATE.STUN;
    }

    public override void Update()
    {

    }


    public override void Exit()
    {

    }
}

// 둔화 상태(상태이상) : 이동속도 느려짐. 이동시 발자취 마다 생기는 이펙트 추가
// 이펙트는 어떻게 추가할 것인가? 옵저버 패턴 사용..?
public class ChampionSlowDownState : ChampionState
{
    public override void Enter()
    {
        champion.CurState = CHAMPION_STATE.SLOWDOWN;
    }

    public override void Update()
    {

    }


    public override void Exit()
    {

    }
}

public class ChampionAirborneState : ChampionState
{
    public override void Enter()
    {
        champion.CurState = CHAMPION_STATE.AIRBORNE;
    }

    public override void Update()
    {

    }


    public override void Exit()
    {

    }
}