using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoemin
{

    /// <summary>
    /// 스킬이나 공격 버튼 누를 때 공격 범위를 그려줄 클래스
    /// 만약, 즉발 스킬인 경우에는 참조하는 Skill 에서 InvokeSKill 함수 호출하여 실행
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
            Debug.Log("조준선 지워짐");
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


