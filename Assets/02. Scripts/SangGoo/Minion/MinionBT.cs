using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MinionBT : MonoBehaviour
{
    SelectorNode rootNode;

    // Depth 1
    SequenceNode attackSequnce;
    SequenceNode chaseSequnce;
    public ActionNode moveAction;

    // Depth 2
    public ActionNode targetInAttackRange;
    public ActionNode attackAction;

    public ActionNode targetInChaseRange;
    public ActionNode chaseAction;

    private void Start()
    {
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

       
        attackSequnce.AddChild(targetInAttackRange);
        attackSequnce.AddChild(attackAction);
        
        //////////////////////////////////////////////////////////////////

        // ChaseSequnce
        targetInChaseRange = new ActionNode();
        chaseAction = new ActionNode();

        chaseSequnce.AddChild(targetInChaseRange);
        chaseSequnce.AddChild(chaseAction);

        //////////////////////////////////////////////////////////////////////
    }

    private void Update()
    {
        rootNode.Evaluate();
    }

   
}
