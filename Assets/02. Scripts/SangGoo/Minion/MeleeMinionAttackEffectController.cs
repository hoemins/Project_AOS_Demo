using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMinionAttackEffectController : MonoBehaviour
{
    public Type type = typeof(MeleeMinionAttackEffectController);

    private void OnDisable()
    {
        PoolManager.instacne.ReturnPool(type, gameObject);
    }
}
