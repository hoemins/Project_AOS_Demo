using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoemin
{
    /// <summary>
    /// 다중 오브젝트 풀링에 사용될 풀링매니저
    /// </summary>
    public class ObjectPoolManager : Singleton<ObjectPoolManager>
    {
        [System.Serializable]
        private class ObjectInfo
        {
            public string objName;
            public GameObject prefab;
            public int count;
        }

        // 생성할 오브젝트들의 정보들
        [SerializeField] ObjectInfo[] objectInfos;
        [SerializeField] Transform poolObjParent;

        Dictionary<string, Queue<GameObject>> objectPoolDic;
        Dictionary<string, GameObject> goDic;

        private void Start()
        {
            objectPoolDic = new Dictionary<string, Queue<GameObject>>();
            goDic = new Dictionary<string, GameObject>();
            InitObjectPool();
        }

        private void InitObjectPool()
        {
            if(objectInfos != null)
            {
                for(int i = 0; i < objectInfos.Length; i++)
                {
                    // 오브젝트를 담을 큐 생성
                    Queue<GameObject> pool = new Queue<GameObject>();

                    // 이미 등록된 프리팹이면 리턴
                    if (goDic.ContainsKey(objectInfos[i].objName)) { return; }

                    // 그게 아니라면 오브젝트 딕셔너리에 등록
                    goDic.Add(objectInfos[i].objName, objectInfos[i].prefab);

                    // 풀 딕셔너리에 풀 등록
                    objectPoolDic.Add(objectInfos[i].objName,pool);

                    int count = objectInfos[i].count;

                    while (count > 0) 
                    {
                        GameObject temp = Instantiate(objectInfos[i].prefab);
                        temp.SetActive(false);
                        temp.transform.parent = poolObjParent;
                        objectPoolDic[objectInfos[i].objName].Enqueue(temp);
                        count--;
                    }

                }
                
            }
        }

        public GameObject GetGo(string name)
        {
            if (goDic.ContainsKey(name) == false)
                return null;
            return objectPoolDic[name].Dequeue();
        }

        public void ReturnPool(GameObject go)
        {
            if (goDic.ContainsKey(go.name))
            {
                go.SetActive(false);
                objectPoolDic[go.name].Enqueue(go);
            }
            else
                return;
        }
    }
}
