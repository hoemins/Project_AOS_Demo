using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MinionBT : MonoBehaviour
{
    SelectorNode rootNode;

    SequenceNode attackSequnce;
    SequenceNode chaseSequnce;
    ActionNode moveAction;

    ActionNode targetInRange;
    ActionNode attackAction;

    ActionNode chaseAction;

    bool isAttackable;

    [SerializeField] float atkRange;

    DetectComponent detectComponent;
    GameObject targetObj;

    private void Start()
    {
        detectComponent = GetComponent<DetectComponent>();

        // Depth 1
        rootNode = new SelectorNode();

        attackSequnce = new SequenceNode();
        chaseSequnce = new SequenceNode();
        moveAction = new ActionNode();

        rootNode.AddChild(attackSequnce);
        rootNode.AddChild(chaseSequnce);
        rootNode.AddChild(moveAction);

        // Depth 2
        targetInRange = new ActionNode();
        attackAction = new ActionNode();

        targetInRange.action += () =>
        {   

            return INode.State.Fail; 
        };

        attackSequnce.AddChild(targetInRange);
    }
}
