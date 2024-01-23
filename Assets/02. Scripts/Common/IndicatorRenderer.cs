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
        public Indicator[] indicators;
       

        private void Start()
        {
            owner = GetComponentInParent<Champion>();
        }

        public void DrawIndicator(int index)
        {
            if (indicators[index].IsOn) { return; }
            if(index == (int)INDICATOR_ENUM.Attack)
            {
                indicators[index].gameObject.SetActive(true);
                indicators[index].IsOn = true;
                return;
            }
            if (owner.SkillList[index].IsCool) return;

            for(int i = 0; i < indicators.Length; i++)
            {
                if (indicators[i].IsOn)
                {
                    indicators[i].gameObject.SetActive(false);
                    indicators[i].IsOn = false;
                }
            }
            indicators[index].gameObject.SetActive(true);
            indicators[index].IsOn = true;
        }

        public void EraseIndicator(int index)
        {
            Debug.Log("���ؼ� ������");
            indicators[index].gameObject.SetActive(false);
            StartCoroutine(EraseIndicatorCor(index));
        }

        IEnumerator EraseIndicatorCor(int index)
        {
            yield return new WaitForSeconds(0.5f);
            indicators[index].IsOn = false;
        }
    }
}


