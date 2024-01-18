using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonPlayerUIController : MonoBehaviour
{
    public Image hpBar;

    public void SetUIPos()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    public void SetHpbar(int hp, int maxHp)
    {
        hpBar.fillAmount = (float)((float)hp / (float)maxHp);
    }
}
