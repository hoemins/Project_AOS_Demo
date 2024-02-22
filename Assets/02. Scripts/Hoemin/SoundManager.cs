using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public GameObject soundComponentPrefab;
    public Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject temp = Instantiate(soundComponentPrefab);
            temp.SetActive(false);
            pool.Enqueue(temp);
        }
    }

    private SoundComponent Pop()
    {
        GameObject popObj = pool.Dequeue();
        popObj.SetActive(true);
        return popObj.GetComponent<SoundComponent>();
    }

    public void ReturnPool(GameObject returnObj)
    {
        returnObj.SetActive(false);
        pool.Enqueue(returnObj);
    }

    public void Play(AudioClip clip, Transform target = null)
    {
        SoundComponent temp = Pop();
        temp.transform.parent = target;
        temp.Play(clip);
    }


}
