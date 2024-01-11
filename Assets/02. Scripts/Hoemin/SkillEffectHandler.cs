using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectHandler : MonoBehaviour
{
    [SerializeField] GameObject firePosition;
    public List<GameObject> effectList;

    public void CreateEffect()
    {
        Instantiate(effectList[0],firePosition.transform.position,Quaternion.identity);
       
    }
}
