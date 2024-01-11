using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

namespace Hoemin // ���ӽ����̽� �����Ͽ� ����� ��
{
    public class ChampionMoveController : MonoBehaviour
    {
        [Header("è�Ǿ� �̵�")]
        [SerializeField] private GameObject markerObject;
        private const int rotSpeed = 8;
        NavMeshAgent agent;

        private IObjectPool<Marker> markerPool;

        public NavMeshAgent Agent { get { return agent; }}
        private void Awake()
        {
            markerPool = new ObjectPool<Marker>(CreateMarker, OnGetMarker, OnReleaseMarker, OnDestroyMarker,maxSize:20);
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
                    var marker = markerPool.Get();
                    marker.transform.position = hitInfo.point;
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

        private Marker CreateMarker()
        {
            Marker marker = Instantiate(markerObject).GetComponent<Marker>();
            marker.SetManagedPool(markerPool);
            return marker;
        }

        private void OnGetMarker(Marker marker)
        {
            marker.gameObject.SetActive(true); 
        }

        private void OnReleaseMarker(Marker marker)
        {
            marker.gameObject.SetActive(false);
        }

        private void OnDestroyMarker(Marker marker)
        {
            Destroy(marker.gameObject);
        }

    }
}

