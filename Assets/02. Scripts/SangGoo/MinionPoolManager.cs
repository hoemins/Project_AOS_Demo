using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinionPoolManager : MonoBehaviour
{
    public static MinionPoolManager instacne;
    public static Dictionary<Type, Queue<GameObject>> poolDic = new Dictionary<Type, Queue<GameObject>>();

    private void Awake()
    {
        if (instacne == null)
            instacne = this;
        else
            Destroy(gameObject);
    }

    public void CreatePool(Type minon_Tpye)
    {
        if (poolDic.ContainsKey(minon_Tpye))
            return;

        poolDic.Add(minon_Tpye, new Queue<GameObject>());
    }

    public void Enqueue(Type minion_Type, GameObject go, Transform parent)
    {
        GameObject createObject = Instantiate(go, parent);
        createObject.SetActive(false);
        poolDic[minion_Type].Enqueue(createObject);
    }

    public GameObject Dequeue(Type minon_Tpye)
    {
        return poolDic[minon_Tpye]?.Dequeue();
    }

    public void ReturnPool(Type minon_Tpye, GameObject go)
    {
        go.SetActive(false);
        poolDic[minon_Tpye].Enqueue(go);
    }
}
