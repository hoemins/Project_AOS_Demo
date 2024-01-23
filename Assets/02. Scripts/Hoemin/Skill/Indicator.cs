using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] bool isOn;
    public bool IsOn
    {
        get { return isOn; }
        set { isOn = value; }
    }

    private void Start()
    {
        isOn = false;
    }
}
