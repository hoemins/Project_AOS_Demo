using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionIdleState : ChampionState
{
    public override void Enter()
    {
        Debug.Log("Champ IDle");
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {

    }
}

public class ChampionMoveState : ChampionState
{
    public override void Enter()
    {

    }

    public override void Update()
    {

    }


    public override void Exit()
    {

    }
}

public class ChampionAttackState : ChampionState
{
    public override void Enter()
    {

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

    }

    public override void Update()
    {

    }


    public override void Exit()
    {

    }
}

// ��ȭ ����(�����̻�) : �̵��ӵ� ������. �̵��� ������ ���� ����� ����Ʈ �߰�
// ����Ʈ�� ��� �߰��� ���ΰ�? ������ ���� ���..?
public class ChampionSlowDownState : ChampionState
{
    public override void Enter()
    {

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

    }

    public override void Update()
    {

    }


    public override void Exit()
    {

    }
}