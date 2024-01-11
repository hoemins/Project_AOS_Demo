using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Marker : MonoBehaviour
{
    IObjectPool<Marker> managedPool;
    private void OnEnable()
    {
        Invoke("DestroyMarker", 1.5f);
    }

    public void SetManagedPool(IObjectPool<Marker> managedPool)
    {
        this.managedPool = managedPool;
    }

    public void DestroyMarker()
    {
        managedPool.Release(this);
    }
}
