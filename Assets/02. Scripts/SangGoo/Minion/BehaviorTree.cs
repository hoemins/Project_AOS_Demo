using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INode
{
    public enum State
    {
        Run,
        Success,
        Fail
    }

    public State Evaluate();
}

public class ActionNode : INode
{
    public Func<INode.State> action = null;

    public INode.State Evaluate()
    {
        return action();
    }
}

public class SelectorNode : INode
{
    List<INode> childs = new List<INode>();

    public INode.State Evaluate()
    {
        foreach (INode node in childs)
        {
            switch (node.Evaluate())
            {
                case INode.State.Success:
                    return INode.State.Success;
                case INode.State.Run:
                    return INode.State.Run;
            }
        }
        return INode.State.Success;
    }

    public void AddChild(INode child)
    {
        childs.Add(child);
    }
}

public class SequenceNode : INode
{
    List<INode> childs = new List<INode>();

    public INode.State Evaluate()
    {
        foreach (INode node in childs)
        {
            if (node.Evaluate() == INode.State.Fail)
            {
                return INode.State.Fail;
            }
        }
        return INode.State.Success;
    }

    public void AddChild(INode child)
    {
        childs.Add(child);
    }
}

public class BehaviorTree : MonoBehaviour
{

}
