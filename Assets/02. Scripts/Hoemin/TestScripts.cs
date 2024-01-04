using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hoemin // ���ӽ����̽� �����Ͽ� ����� ��
{
    /// <summary>
    /// �׽�Ʈ�� �̵� è�Ǿ� �̵� ��ũ��Ʈ
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
                // desiredVelocity : ��ֹ��� ���ϴ� �� ���� ����� �ӵ�
                Vector3 direction = agent.desiredVelocity;
                Quaternion targetAngle = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation,targetAngle,Time.deltaTime*8);
            }
        }


    }
}

