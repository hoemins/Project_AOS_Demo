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

    public IObjectPool<GameObject> Pool { get; set; }

    private void Start()
    {

    }

    private void CreateFlashEffect()
    {

    }


}
