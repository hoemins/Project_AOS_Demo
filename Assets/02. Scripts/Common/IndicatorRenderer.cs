using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ų�̳� ���� ��ư ���� �� ���� ������ �׷��� Ŭ����
/// ����, ��� ��ų�� ��쿡�� �����ϴ� Skill ���� InvokeSKill �Լ� ȣ���Ͽ� ����
/// </summary>
public class IndicatorRenderer : MonoBehaviour
{
    private Champion owner;
    public GameObject[] indicators;

    private void Start()
    {
        owner = GetComponentInParent<Champion>();
    }

    public void DrawIndicator()
    {
        Debug.Log("��ų ���� ǥ��");
        indicators[0].SetActive(true);
    }

    public void EraseIndicator()
    {
        Debug.Log("��ų ���� ���");
        indicators[0].SetActive(false);
    }
}
