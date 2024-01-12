using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MinionBT : MonoBehaviour
{
    SelectorNode rootNode;

    // Depth 1
    SequenceNode attackSequnce;
    SequenceNode chaseSequnce;
    ActionNode moveAction;

    // Depth 2
    ActionNode targetInAttackRange;
    ActionNode attackAction;

    ActionNode targetInChaseRange;
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

        // AttackSequnce
        targetInAttackRange = new ActionNode();
        attackAction = new ActionNode();

        targetInAttackRange.action += () =>
        {   
            return INode.State.Fail; 
        };
        attackAction.action += () =>
        {
            return INode.State.Fail;
        };

        attackSequnce.AddChild(targetInAttackRange);
        attackSequnce.AddChild(attackAction);
        
        //////////////////////////////////////////////////////////////////

        // ChaseSequnce
        targetInChaseRange = new ActionNode();
        chaseAction = new ActionNode();

        targetInChaseRange.action += () =>
        {
            return INode.State.Success;
        };
        chaseAction.action += () =>
        {
            if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("추격 중");
                return INode.State.Success;
            }
            return INode.State.Fail;
        };

        chaseSequnce.AddChild(targetInChaseRange);
        chaseSequnce.AddChild(chaseAction);

        //////////////////////////////////////////////////////////////////////
        
        // MoveAction
        moveAction.action += () =>
        {
            Debug.Log("이동 중");
            return INode.State.Success;
        };
    }

    private void Update()
    {
        rootNode.Evaluate();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if(detectComponent != null)
            Gizmos.DrawWireSphere(transform.position, detectComponent.DetectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atkRange);
    }
}
