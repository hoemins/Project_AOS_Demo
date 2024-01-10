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

// 챔피언의 공격은 커맨드 패턴만 사용하여 구현하면 어떨까?
// 하지만, "공격상태" 일 때는 다른 행동을 할 수 없고 하게되더라도 공격이 캔슬되게 하고싶은데
// 그렇다면 공격 상태도 같이 구현하여 상태 전환을 시켜주어야 맞는건가?
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

// 고민 : 상태이상 클래스가 스턴기 스킬이 가진 스턴시간을 어떻게 참조해야 좋을까?
// 스킬중에 스턴스킬은 스턴기란 인터페이스를 상속받고 그 인터페이스 내에 정의된 프로퍼티로 가져오면?
public class ChampionStunState : ChampionState
{
    public override void Enter()
    {
        champion.CurState = CHAMPION_STATE.STUN;
        champion.MoveController.Agent.speed = Vector3.zero.magnitude;
    }

    public override void Update()
    {

    }


    public override void Exit()
    {
        champion.MoveController.Agent.speed = champion.ChampionInfo.MoveSpeed;
    }
}

// 둔화 상태(상태이상) : 이동속도 느려짐. 이동시 발자취 마다 생기는 이펙트 추가
// 이펙트는 어떻게 추가할 것인가? 옵저버 패턴 사용..?
// 애니메이션의 add property 활용?
public class ChampionSlowDownState : ChampionState
{
    private const float decreaseAmount = 0.4f;

    public override void Enter()
    {
        champion.CurState = CHAMPION_STATE.SLOWDOWN;
        champion.MoveController.Agent.speed = champion.ChampionInfo.MoveSpeed * (1-decreaseAmount); 
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