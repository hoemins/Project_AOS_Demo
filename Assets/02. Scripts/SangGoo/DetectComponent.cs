using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectComponent : MonoBehaviour, IDetectable
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] private float detectRange;

    public float DetectRange => detectRange;
    public bool IsDetected => colliders.Length > 0;
    public Collider[] Colliders => colliders;
    Collider[] colliders;

    private void Update()
    {
        Detect();
    }

    public void Detect()
    {
        colliders = Physics.OverlapSphere(transform.position, DetectRange, layerMask);
    }
}
