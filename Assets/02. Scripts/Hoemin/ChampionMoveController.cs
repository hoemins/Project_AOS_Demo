using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hoemin // ���ӽ����̽� �����Ͽ� ����� ��
{
    public class ChampionMoveController : MonoBehaviour
    {
        [Header("è�Ǿ� �̵�")]
        [SerializeField] private GameObject markerObject;
        private const int rotSpeed = 8;
        NavMeshAgent agent;



        public NavMeshAgent Agent { get { return agent; }}
        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.acceleration = 50f;
        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    agent.SetDestination(hitInfo.point);
                    GameObject marker = Instantiate(markerObject, hitInfo.point, markerObject.transform.localRotation);
                    Destroy(marker, 1.5f);
                }
            }

            if (agent.desiredVelocity.sqrMagnitude >= 0.1f)
            {
                // desiredVelocity : ��ֹ��� ���ϴ� �� ���� ����� �ӵ�
                Vector3 direction = agent.desiredVelocity;
                Quaternion targetAngle = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, Time.deltaTime * rotSpeed);
            }
        }



    }
}

