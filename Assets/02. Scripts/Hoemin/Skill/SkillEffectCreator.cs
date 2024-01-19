using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;


/// <summary>
/// 이펙트 생성을 담당하는 클래스 , 기본적으로 오브젝트 풀로 구현하려함
/// 참고한 자료에서는 Player 스크립트 역할
/// </summary>
public class SkillEffectCreator : MonoBehaviour
{
    [SerializeField] private GameObject flashEffectObj;
    [SerializeField] private GameObject hitEffectObj;
    [SerializeField] private GameObject[] detachedObj;



    public void CreateFlashEffect(GameObject flashEffect)
    {
        if (flashEffectObj != null)
        {
            GameObject flashInstance = Instantiate(flashEffectObj, transform.position, Quaternion.identity);
            flashInstance.transform.forward = gameObject.transform.forward;
            ParticleSystem flashPs = flashInstance.GetComponent<ParticleSystem>();
            if (flashPs != null)
            {
                Destroy(flashInstance, flashPs.main.duration);
            }
            else
            {
                ParticleSystem flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(flashInstance, flashPsParts.main.duration);
            }
        }
    }

    public void CreateHitEffect(GameObject hitEffect)
    {
        if (hitEffectObj != null)
        {
            var hitInstance = Instantiate(hitEffectObj, transform.position, Quaternion.identity);
            var hitPs = hitInstance.GetComponent<ParticleSystem>();
            if (hitPs != null)
            {
                Destroy(hitInstance, hitPs.main.duration);
            }
            else
            {
                var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitInstance, hitPsParts.main.duration);
            }
            foreach (var detachedPrefab in detachedObj)
            {
                if (detachedPrefab != null)
                {
                    detachedPrefab.transform.parent = null;
                }
            }
            Destroy(gameObject);
        }
    }

}
