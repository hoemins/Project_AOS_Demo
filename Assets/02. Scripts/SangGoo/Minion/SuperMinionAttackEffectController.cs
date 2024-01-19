using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SuperMinionAttackEffectController : MonoBehaviour
{
    public Type type = typeof(SuperMinionAttackEffectController);

    private void OnDisable()
    {
        PoolManager.instacne.ReturnPool(type, gameObject);
    }
}
