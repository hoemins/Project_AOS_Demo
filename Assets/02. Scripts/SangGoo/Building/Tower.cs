using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Tower : Building, IAttackable
{
    private int physicalAtk;
    private float physicalAtkDelay;

    public int PhysicalAtk => physicalAtk;
    public float PhysicalAtkDelay => physicalAtkDelay;

    DetectComponent detectComponent;
    [SerializeField] GameObject targetObj;
    [SerializeField] TowerAttackEffectController atkEffectController;
    protected IEnumerator attackDelayCo;


    private new void Start()
    {
        base.Start();

        physicalAtk = 30;
        physicalAtkDelay = 1.2f;

        buildingInfo = new BuildingInfo("Tower", 1000, 0, 0);
        detectComponent = GetComponent<DetectComponent>();
        atkEffectController = targetObj.GetComponent<TowerAttackEffectController>();
    }

    private void Update()
    {
        if (detectComponent.IsDetected)
        {
            SetTarget();
            if(detectComponent.targetCol != null)
                Attack();
        }
    }
    public void Attack()
    {
        if (detectComponent.targetCol.TryGetComponent<IHitable>(out var target))
        {
            if (attackDelayCo == null)
            {
                attackDelayCo = AttackDelayCo(target);
                StartCoroutine(attackDelayCo);
            }
        }
    }


    public IEnumerator AttackDelayCo(IHitable target)
    {
        yield return new WaitForSeconds(PhysicalAtkDelay);
        Debug.Log("타워의 공격");
        target.Hit(PhysicalAtk);
        attackDelayCo = null;
    }
    public void SetTarget()
    {
        if (detectComponent.targetCol == null)
        {
            foreach (Collider collider in detectComponent.Colliders)
            {
                if (gameObject.tag == collider.tag)
                    continue;

                detectComponent.targetCol = collider;
            }
        }
        else
        {
            if (detectComponent.targetCol.TryGetComponent<IHitable>(out var target))
            {
                if (target.IsDie)
                {
                    detectComponent.targetCol = null;
                    SetTarget();
                }
            }

            if (detectComponent.Colliders.Contains(detectComponent.targetCol) == false)
            {
                foreach (Collider collider in detectComponent.Colliders)
                {
                    if (gameObject.tag == collider.tag)
                        continue;

                    detectComponent.targetCol = collider;
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if(detectComponent != null)
            Gizmos.DrawWireSphere(transform.position, detectComponent.DetectRange);
    }
}
