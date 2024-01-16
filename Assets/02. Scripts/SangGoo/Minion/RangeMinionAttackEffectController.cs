using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangeMinionAttackEffectController : MonoBehaviour
{
    public Minion owner;
    public Type type = typeof(RangeMinionAttackEffectController);

    public Transform targetTransfrom;

    private void Update()
    {
        
    }

    public void SetTarget(Transform target)
    {
        targetTransfrom = target;
    }

    public void SetOwner(Minion minion)
    {
        owner = minion;
    }

    private void OnDisable()
    {
        if (owner == null)
            return;

        PoolManager.instacne.ReturnPool(type, gameObject);
    }
}
