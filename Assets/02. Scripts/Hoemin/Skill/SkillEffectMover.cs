using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SkillEffectMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float skillRange;
    [SerializeField] private Transform firePos;
    private Rigidbody rb;
    private Vector3 direction;
    public Action onHit;
    
    public Transform FirePos { get { return firePos; } set {  firePos = value; } }

    private void OnEnable()
    {
        this.gameObject.transform.position = firePos.position;
        this.gameObject.transform.SetParent(null);
        SetDirection();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (moveSpeed != 0)
        {
            rb.velocity = transform.forward * moveSpeed;
            if (Vector3.Distance(firePos.position, transform.position) >= skillRange)
            {
                Debug.Log("사라짐");
                this.gameObject.SetActive(false);
            }
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("적이 맞아요");
            onHit?.Invoke();
        }
    }
}
