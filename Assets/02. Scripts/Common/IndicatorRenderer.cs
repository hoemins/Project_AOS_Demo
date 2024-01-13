using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스킬이나 공격 버튼 누를 때 공격 범위를 그려줄 클래스
/// </summary>
public class IndicatorRenderer : MonoBehaviour
{
    public void DrawIndicator()
    {
        Debug.Log("스킬 조준 표시");
    }

    public void EraseIndicator()
    {
        Debug.Log("스킬 조준 취소");
    }
}
