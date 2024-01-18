using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using System;
namespace Hoemin
{
    public class SkillEffectController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 15f;
        [SerializeField] private float skillRange;
        [SerializeField] private float hitOffset = 0f;
        [SerializeField] private bool useFirePointRotation;
        [SerializeField] private Vector3 rotationOffset = Vector3.zero;
        [SerializeField] private GameObject hitEffectObj;
        [SerializeField] private GameObject flashEffectObj;
        [SerializeField] private GameObject[] detached;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private Vector3 firePos;
        private Rigidbody rb;
        private Vector3 direction;

        public Action<IHitable> atkAction;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            CreateFlashEffect();
            SetDirection();
            // 발사 위치 저장
            firePos = transform.position;

        }

        private void SetDirection()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                direction = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                transform.forward = direction;
            }
        }

        private void CreateFlashEffect()
        {
            if (flashEffectObj != null)
            {
                GameObject flashInstance = Instantiate(flashEffectObj, transform.position, Quaternion.identity);
                flashInstance.transform.forward = gameObject.transform.forward;
                ParticleSystem flashPs = flashInstance.GetComponent<ParticleSystem>();
                if (flashPs != null)
                {
                    Destroy(flashInstance, flashPs.main.duration);
                }
                else
                {
                    ParticleSystem flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(flashInstance, flashPsParts.main.duration);
                }
            }
        }


        private void Update()
        {
            if(moveSpeed != 0)
            {
                rb.velocity = transform.forward * moveSpeed;
                if (Vector3.Distance(firePos, transform.position) >= skillRange)
                    Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            

            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") && other.TryGetComponent<IHitable>(out var target))
            {
                Debug.Log(other.gameObject.name + "스킬 맞았음");
                rb.constraints = RigidbodyConstraints.FreezeAll;
                moveSpeed = 0;
                
                atkAction(target);
                

                if (hitEffectObj != null)
                {
                    var hitInstance = Instantiate(hitEffectObj, transform.position, Quaternion.identity);
                    var hitPs = hitInstance.GetComponent<ParticleSystem>();
                    if (hitPs != null)
                    {
                        Destroy(hitInstance, hitPs.main.duration);
                    }
                    else
                    {
                        var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                        Destroy(hitInstance, hitPsParts.main.duration);
                    }
                    foreach (var detachedPrefab in detached)
                    {
                        if (detachedPrefab != null)
                        {
                            detachedPrefab.transform.parent = null;
                        }
                    }
                    Destroy(gameObject);
                }

                
            }
            
        }


    }


    





}

