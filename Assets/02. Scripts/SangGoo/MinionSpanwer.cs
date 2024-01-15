using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class MinionSpanwer : MonoBehaviour
{
    public GameObject[] minonPrefabs;
    public Transform goalPoint;

    Type meleeMinionType;
    Type rangeMinionType;
    Type canonMinionType;

    int curSpanwCount;

    int curWave;

    private void Start()
    {
        curSpanwCount = 0;
        curWave = 0;

        meleeMinionType = typeof(MeleeMinion);
        rangeMinionType = typeof(RangeMinion);
        canonMinionType = typeof(CanonMinion);

        PoolManager.instacne.CreatePool(meleeMinionType);
        PoolManager.instacne.CreatePool(rangeMinionType);
        PoolManager.instacne.CreatePool(canonMinionType);

        for (int i = 0; i < 100; i++)
        {
            PoolManager.instacne.Enqueue(meleeMinionType, minonPrefabs[0]);
            PoolManager.instacne.Enqueue(rangeMinionType, minonPrefabs[1]);
        }
        for (int i = 0; i < 30; i++)
            PoolManager.instacne.Enqueue(canonMinionType, minonPrefabs[2]);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnCo());
        }
    }

    public void Spawn(Type type)
    {
        GameObject spawnObject = PoolManager.instacne.Dequeue(type);
        spawnObject.transform.position = transform.position;
        spawnObject.tag = gameObject.tag;

        if (spawnObject.TryGetComponent<Minion>(out var minion))
        {
            minion.goalPoint = goalPoint;
        }

        spawnObject.SetActive(true);
    }

    IEnumerator SpawnCo()
    {
        curWave++;
        while (curSpanwCount < 3)
        {
            curSpanwCount++;
            Spawn(meleeMinionType);
            yield return new WaitForSeconds(1f);
        }
        curSpanwCount = 0;

        if (curWave % 3 == 0)
        {
            Spawn(canonMinionType);
            yield return new WaitForSeconds(1f);
        }

        while (curSpanwCount < 3)
        {
            curSpanwCount++;
            Spawn(rangeMinionType);
            yield return new WaitForSeconds(1f);
        }
        curSpanwCount = 0;

        yield return null;
    }
}
