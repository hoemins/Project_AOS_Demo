using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스킬이나 공격 버튼 누를 때 공격 범위를 그려줄 클래스
/// 만약, 즉발 스킬인 경우에는 참조하는 Skill 에서 InvokeSKill 함수 호출하여 실행
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
        Debug.Log("스킬 조준 표시");
        indicators[0].SetActive(true);
    }

    public void EraseIndicator()
    {
        Debug.Log("스킬 조준 취소");
        indicators[0].SetActive(false);
    }
}
