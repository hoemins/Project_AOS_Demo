using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorRotator : MonoBehaviour
{
    public Vector3 direction;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            direction = new Vector3(hit.point.x,transform.position.y, hit.point.z) - transform.position;
            transform.forward = direction;
        }
    }
}
