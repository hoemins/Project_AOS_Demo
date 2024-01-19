using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoemin
{
    /// <summary>
    /// ���� ������Ʈ Ǯ���� ���� Ǯ���Ŵ���
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

        // ������ ������Ʈ���� ������
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
                    // ������Ʈ�� ���� ť ����
                    Queue<GameObject> pool = new Queue<GameObject>();

                    // �̹� ��ϵ� �������̸� ����
                    if (goDic.ContainsKey(objectInfos[i].objName)) { return; }

                    // �װ� �ƴ϶�� ������Ʈ ��ųʸ��� ���
                    goDic.Add(objectInfos[i].objName, objectInfos[i].prefab);

                    // Ǯ ��ųʸ��� Ǯ ���
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
