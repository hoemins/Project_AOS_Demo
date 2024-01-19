using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObjectPool : Singleton<SkillObjectPool>
{
    [SerializeField] private GameObject[] effects;
    Queue<GameObject> effectPool;
    [SerializeField] private int size = 10;

    private void Start()
    {
        effectPool = new Queue<GameObject>();

        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < effects.Length; j++)
            {
                GameObject temp = Instantiate(effects[j],transform.position,transform.rotation);
                temp.SetActive(false);
                effectPool.Enqueue(temp);
            }
        }
    }


    public void PopObj(Vector3 pos, Quaternion rot)
    {
        GameObject dequeueObj = effectPool.Dequeue();

        dequeueObj.transform.position = pos;
        dequeueObj.transform.rotation = rot;

        dequeueObj.SetActive(true);
    }

    public void ReturnPool(GameObject returnObj)
    {
        returnObj.SetActive(false);
        effectPool.Enqueue(returnObj);
    }

}
