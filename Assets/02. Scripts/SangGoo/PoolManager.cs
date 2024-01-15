using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instacne;
    public Dictionary<Type, Queue<GameObject>> poolDic = new Dictionary<Type, Queue<GameObject>>();

    private void Awake()
    {
        if (instacne == null)
            instacne = this;
        else
            Destroy(gameObject);
    }

    public void CreatePool(Type type)
    {
        if (poolDic.ContainsKey(type))
            return;

        poolDic.Add(type, new Queue<GameObject>());
    }

    public void Enqueue(Type type, GameObject go)
    {
        GameObject createObject = Instantiate(go, transform);
        createObject.SetActive(false);
        poolDic[type].Enqueue(createObject);
    }

    public GameObject Dequeue(Type type)
    {
        return poolDic[type]?.Dequeue();
    }

    public void ReturnPool(Type type, GameObject go)
    {
        go.SetActive(false);
        poolDic[type].Enqueue(go);
    }
}
