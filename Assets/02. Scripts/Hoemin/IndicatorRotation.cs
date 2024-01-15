using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorRotation : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
