using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectCreator : MonoBehaviour
{
    [SerializeField] GameObject firePosition;
    public List<GameObject> effectList;

    public void CreateEffect(int index)
    {
        Instantiate(effectList[index],firePosition.transform.position,Quaternion.identity);
        
    }
}
