using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMinionAttackEffectController : MonoBehaviour
{
    public Minion owner;
    public Type type = typeof(MeleeMinionAttackEffectController);

    public void SetOwner(Minion minion)
    {
        owner = minion;
    }

    private void OnDisable()
    {
        if(owner == null)
            return;

        PoolManager.instacne.ReturnPool(type, gameObject);
    }
}
