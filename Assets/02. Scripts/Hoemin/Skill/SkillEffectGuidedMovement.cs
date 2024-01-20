using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillEffectGuidedMovement : MonoBehaviour
{
    [SerializeField] private Transform firePos;
    [SerializeField] private Champion owner;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private int speed;
    public event Action onHit;
    Vector3 direction;

    Rigidbody rb;
    public Transform FirePos { get { return firePos; } set { firePos = value; } }
    private void OnEnable()
    {
        gameObject.transform.SetParent(null);
        targetTransform = owner.DetectComponent.Colliders[0].transform;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        onHit += () => { gameObject.SetActive(false); };
        onHit += () => { gameObject.transform.SetParent(firePos); };
        onHit += () => { gameObject.transform.position = firePos.position; };

    }

    

    private void Update()
    {
        direction = (targetTransform.position - transform.position).normalized;
        transform.forward = direction;
        rb.velocity = direction * speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("적이 유도맞아요");
            onHit?.Invoke();
        }
    }

}
