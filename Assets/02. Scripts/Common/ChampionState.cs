using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionIdleState : ChampionState
{
    public override void Enter()
    {
        champion.CurState = CHAMPION_STATE.IDLE;
        champion.Anim.SetBool("IsMove", false);
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
        champion.Anim.SetBool("IsMove", true);
    }

    public override void Update()
    {
        if (champion.CurState == CHAMPION_STATE.STUN || champion.CurState == CHAMPION_STATE.AIRBORNE || champion.CurState == CHAMPION_STATE.DIE) { return; }

        if (champion.MoveController.Agent.velocity == Vector3.zero)
            sm.SetState((int)CHAMPION_STATE.IDLE);
    }


    public override void Exit()
    {
        champion.Anim.SetBool("IsMove", false);
    }
}

// è�Ǿ��� ������ Ŀ�ǵ� ���ϸ� ����Ͽ� �����ϸ� ���?
// ������, "���ݻ���" �� ���� �ٸ� �ൿ�� �� �� ���� �ϰԵǴ��� ������ ĵ���ǰ� �ϰ������
// �׷��ٸ� ���� ���µ� ���� �����Ͽ� ���� ��ȯ�� �����־�� �´°ǰ�?
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

// ��� : �����̻� Ŭ������ ���ϱ� ��ų�� ���� ���Ͻð��� ��� �����ؾ� ������?
// ��ų�߿� ���Ͻ�ų�� ���ϱ�� �������̽��� ��ӹް� �� �������̽� ���� ���ǵ� ������Ƽ�� ��������?
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

// ��ȭ ����(�����̻�) : �̵��ӵ� ������. �̵��� ������ ���� ����� ����Ʈ �߰�
// ����Ʈ�� ��� �߰��� ���ΰ�? ������ ���� ���..?
// �ִϸ��̼��� add property Ȱ��?
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