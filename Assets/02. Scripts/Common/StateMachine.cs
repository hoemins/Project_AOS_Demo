using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine
{
    object GetOwner();
    void SetState(int stateNum);
}

public class StateMachine<T> : IStateMachine where T : class
{
    Dictionary<int, BasicState> stateDic;
    private BasicState curState;
    private T owner;
    
    public T Owner { get { return owner; } }

    public StateMachine(T owner)
    {
        this.owner = owner;
        stateDic = new Dictionary<int, BasicState>();
    }

    public void AddState(int stateNum, BasicState state)
    {
        if (stateDic.ContainsKey(stateNum)) return;
        stateDic.Add(stateNum, state);
        state.StateInit(this);
    }

    public void SetState(int stateNum)
    {
        if(stateDic.ContainsKey(stateNum))
        {
            if(curState != null)
            {
                curState.Exit();
            }
            curState = stateDic[stateNum];
            curState.Enter();
        }
    }

    public void Update()
    {
        curState.Update();
    }

    public object GetOwner()
    {
        return Owner;
    }
}
