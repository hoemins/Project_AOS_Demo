using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangeAttackEffectController<T> : MonoBehaviour where T : RangeAttackEffectController<T>
{
    public Type type = typeof(T);

    public Transform targetTransfrom;
    public Action hitAction;

    private void OnEnable()
    {
        hitAction += () => { gameObject.SetActive(false); };
    }

    private void Update()
    {
        if (targetTransfrom != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransfrom.position, 0.1f);
            if (Vector3.Distance(transform.position, targetTransfrom.position) <= 0.3f)
                hitAction();
        }
        else
            gameObject.SetActive(false);
    }

    public virtual void SetTarget(Transform target)
    {
        targetTransfrom = target;
    }

    public virtual void OnDisable()
    {
        if (type == null)
            return;

        targetTransfrom = null;
        hitAction = null;
        PoolManager.instacne.ReturnPool(type, gameObject);
    }
}
