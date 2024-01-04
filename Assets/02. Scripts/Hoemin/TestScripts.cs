using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hoemin // 네임스페이스 구분하여 사용할 것
{
    public class TestScripts : MonoBehaviour
    {
        [SerializeField] private GameObject markerObject;
        NavMeshAgent agent;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray,out RaycastHit hitInfo))
                {
                    agent.SetDestination(hitInfo.point);
                    GameObject marker = Instantiate(markerObject, hitInfo.point,Quaternion.identity);
                }
            }
        }
    }
}

