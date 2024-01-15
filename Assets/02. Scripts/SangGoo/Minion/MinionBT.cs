using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MinionBT : MonoBehaviour
{
    // Depth 0
    SelectorNode rootNode;

    // Depth 1
    SequenceNode attackSequnce;
    SequenceNode chaseSequnce;
    public ActionNode moveAction;

    // Depth 2
    public ActionNode targetInAttackRange;
    public ActionNode targetingToAttack;
    public ActionNode attackAction;

    public ActionNode targetInChaseRange;
    public ActionNode targetingToChase;
    public ActionNode chaseAction;

    private void Awake()
    {
        // Depth 0
        rootNode = new SelectorNode();

        // Depth 1
        attackSequnce = new SequenceNode();
        chaseSequnce = new SequenceNode();
        moveAction = new ActionNode();

        rootNode.AddChild(attackSequnce);
        rootNode.AddChild(chaseSequnce);
        rootNode.AddChild(moveAction);

        // Depth 2

        // AttackSequnce
        targetInAttackRange = new ActionNode();
        targetingToAttack = new ActionNode();
        attackAction = new ActionNode();
       
        attackSequnce.AddChild(targetInAttackRange);
        attackSequnce.AddChild(targetingToAttack);
        attackSequnce.AddChild(attackAction);
        
        //////////////////////////////////////////////////////////////////

        // ChaseSequnce
        targetInChaseRange = new ActionNode();
        targetingToChase = new ActionNode();
        chaseAction = new ActionNode();

        chaseSequnce.AddChild(targetInChaseRange);
        chaseSequnce.AddChild(targetingToChase);
        chaseSequnce.AddChild(chaseAction);
        //////////////////////////////////////////////////////////////////////
    }

    private void Update()
    {
        rootNode.Evaluate();
    }


}
