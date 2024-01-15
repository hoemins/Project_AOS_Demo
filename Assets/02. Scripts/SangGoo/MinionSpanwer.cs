using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class MinionSpanwer : MonoBehaviour
{
    public GameObject[] minonPrefabs;
    public Transform goalPoint;

    Type meleeType;
    Type rangeType;
    Type canonType;

    private void Start()
    {
        meleeType = typeof(MeleeMinion);

        MinionPoolManager.instacne.CreatePool(meleeType);

        for(int i = 0; i < 30; i++)
            MinionPoolManager.instacne.Enqueue(meleeType, minonPrefabs[0], transform);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn(meleeType);
        }
    }

    public void Spawn(Type type)
    {
        GameObject spawnObject = MinionPoolManager.instacne.Dequeue(type);
        spawnObject.transform.position = transform.position;

        if (spawnObject.TryGetComponent<Minion>(out var minion))
            minion.goalPoint = goalPoint;

        spawnObject.SetActive(true);
    }
}
