using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hoemin // 네임스페이스 구분하여 사용할 것
{
    /// <summary>
    /// 테스트용 이동 챔피언 이동 스크립트
    /// </summary>
    public class TestScripts : MonoBehaviour
    {
        [SerializeField] private GameObject markerObject;
        NavMeshAgent agent;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.acceleration = 50f;
            
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray,out RaycastHit hitInfo))
                {
                    agent.SetDestination(hitInfo.point);
                    GameObject marker = Instantiate(markerObject, hitInfo.point,markerObject.transform.localRotation);
                }
            }
            
            if(agent.desiredVelocity.sqrMagnitude >= 0.1f)
            {
                Vector3 direction = agent.desiredVelocity;
                Quaternion targetAngle = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation,targetAngle,Time.deltaTime*8);
            }
        }


    }
}

