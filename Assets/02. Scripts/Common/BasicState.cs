using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicState
{
    public IStateMachine sm;

    public virtual void StateInit(IStateMachine sm) 
    {
        this.sm = sm;
    }
    public virtual void Enter() { }
    public abstract void Update();
    public virtual void Exit() { }
}

public class ChampionState : BasicState
{
    protected Champion champion;
    public override void StateInit(IStateMachine sm)
    {
        this.sm = sm;
        champion = (Champion)sm.GetOwner();
    }
    public override void Update()
    {
        
    }
}

