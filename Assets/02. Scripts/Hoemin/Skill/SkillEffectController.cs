using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Hoemin
{
    public class SkillEffectController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 15f;
        [SerializeField] private float hitOffset = 0f;
        [SerializeField] private bool useFirePointRotation;
        [SerializeField] private Vector3 rotationOffset = Vector3.zero;
        [SerializeField] private GameObject hitEffectObj;
        [SerializeField] private GameObject flashEffectObj;
        [SerializeField] private GameObject[] detached;
        [SerializeField] private LayerMask targetLayer;
        private Rigidbody rb;
        private Vector3 direction;


        void Start()
        {
            rb = GetComponent<Rigidbody>();

            CreateFlashEffect();
            SetDirection();

            Destroy(gameObject, 5);
        }

        private void SetDirection()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                direction = (hit.point + Vector3.up) - transform.position;
                direction.Normalize();
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
                rb.velocity = direction*moveSpeed;
            }
        }


        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == targetLayer)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                moveSpeed = 0;

                ContactPoint contact = collision.contacts[0];
                Vector3 pos = contact.point + contact.normal * hitOffset;
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);

                if (hitEffectObj != null)
                {
                    var hitInstance = Instantiate(hitEffectObj, pos, rot);
                    if (useFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
                    else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
                    else { hitInstance.transform.LookAt(contact.point + contact.normal); }

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

