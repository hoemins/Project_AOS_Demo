using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;


/// <summary>
/// ����Ʈ ������ ����ϴ� Ŭ���� , �⺻������ ������Ʈ Ǯ�� �����Ϸ���
/// ������ �ڷῡ���� Player ��ũ��Ʈ ����
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
