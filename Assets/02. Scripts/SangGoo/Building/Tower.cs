using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Building, IAttackable
{
    private int physicalAtk;
    private float atkRange;
    private float physicalAtkDelay;

    public int PhysicalAtk => physicalAtk;
    public float AtkRange => atkRange;
    public float PhysicalAtkDelay => physicalAtkDelay;

    DetectComponent detectComponent;
    GameObject targetObj;

    private new void Start()
    {
        base.Start();

        buildingInfo = new BuildingInfo("Tower", 1000, 10, 10);
        detectComponent = GetComponent<DetectComponent>();
    }

    private void Update()
    {
        if (detectComponent.IsDetected)
            PhysicalAttack();
    }

    public void PhysicalAttack()
    {

    }

    public void SetTarget()
    {

    }
}
