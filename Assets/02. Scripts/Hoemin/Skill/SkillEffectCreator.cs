using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Rendering.DebugUI.Table;
using Unity.Burst.CompilerServices;


/// <summary>
/// ����Ʈ ������ ����ϴ� Ŭ����
/// </summary>
public class SkillEffectCreator : MonoBehaviour
{
    [SerializeField] private GameObject flashEffectObj;
    [SerializeField] private GameObject hitEffectObj;
    [SerializeField] private GameObject[] detachedObj;
    SkillEffectMover skillEffectMover;
    SkillEffectGuidedMovement skillEffectGuided;

    private void Start()
    {
        skillEffectMover = GetComponent<SkillEffectMover>();
        skillEffectGuided = GetComponent<SkillEffectGuidedMovement>();
        CreateFlashEffect();

        if(skillEffectMover != null)
        {
            skillEffectMover.onHit += CreateHitEffect;
        }
        if(skillEffectGuided != null)
        {
            skillEffectGuided.onHit += CreateHitEffect;
        }
        
        
    }

    public void CreateFlashEffect()
    {
        if (flashEffectObj != null)
        {
            flashEffectObj.SetActive(true);
            Debug.Log("������");

            flashEffectObj.transform.forward = gameObject.transform.forward;
            ParticleSystem flashPs = flashEffectObj.GetComponent<ParticleSystem>();
            if (flashPs != null)
            {
                SetActiveCor(flashEffectObj, flashPs.main.duration);
            }
            else
            {
                ParticleSystem flashPsParts = flashEffectObj.transform.GetChild(0).GetComponent<ParticleSystem>();
                SetActiveCor(flashEffectObj, flashPsParts.main.duration);
            }
        }
    }

    public void CreateHitEffect()
    {
        if (hitEffectObj != null)
        {
            hitEffectObj.SetActive(true);
            //var hitInstance = Instantiate(hitEffectObj,transform.position,Quaternion.identity);
            Debug.Log("ó�¾Ƽ� ����");           
            var hitPs = hitEffectObj.GetComponent<ParticleSystem>();
            if (hitPs != null)
            {
                SetActiveCor(hitEffectObj, hitPs.main.duration);
            }
            else
            {
                var hitPsParts = hitEffectObj.transform.GetChild(0).GetComponent<ParticleSystem>();
                SetActiveCor(hitEffectObj, hitPsParts.main.duration);
            }
            foreach (var detachedPrefab in detachedObj)
            {
                if (detachedPrefab != null)
                {
                    detachedPrefab.transform.parent = null;
                }
            }
            gameObject.SetActive(false);
        }
    }

    IEnumerator SetActiveCor(GameObject go,float time)
    {
        yield return new WaitForSeconds(time);
        go.SetActive(false);
        Transform firePosition;

        if (skillEffectGuided != null) firePosition = skillEffectGuided.FirePos;
        else firePosition=skillEffectMover.FirePos;

        go.transform.position = firePosition.position;
    }

}
