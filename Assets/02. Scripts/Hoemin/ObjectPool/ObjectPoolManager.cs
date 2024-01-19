using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Hoemin
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager instance = null;

        public int defaultCapacity = 10;
        public int maxPoolSize = 20;
        public GameObject projectilePrefab;

        public IObjectPool<GameObject> Pool { get; private set; }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);


        }

        private void Init()
        {
            //Pool = new ObjectPool<GameObject>();


        }



        private GameObject CreatePooledItem()
        {
            GameObject poolObj = Instantiate(projectilePrefab);
            //poolObj.GetComponent<ProjectileMover>().Pool = this.Pool;
            return poolObj;
        }

        private void OnTakeFromPool(GameObject poolObj)
        {
            poolObj.SetActive(true);
        }

        private void OnReturnedToPool(GameObject poolObj)
        {
            poolObj.SetActive(false);
        }

        private void OnDestroyPoolObject(GameObject poolObj)
        {
            Destroy(poolObj);
        }

    }
}

