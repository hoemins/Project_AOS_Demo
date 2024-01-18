using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoemin
{

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

        public void DrawIndicator(int index)
        {
            if(index == (int)INDICATOR_ENUM.Attack)
            {
                indicators[index].SetActive(true);
                return;
            }

            if (owner.SkillList[index].IsCool) return;
            Debug.Log("��ų ���� ǥ��");
            indicators[index].SetActive(true);
        }

        public void EraseIndicator(int index)
        {
            Debug.Log("��ų ���� ���");
            indicators[index].SetActive(false);
        }
    }
}


