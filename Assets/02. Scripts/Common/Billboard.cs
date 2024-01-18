using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Camera billboardCam;
    Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.transform.forward = billboardCam.transform.position - transform.position;
    }
}
