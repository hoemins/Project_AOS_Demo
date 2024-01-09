using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("상단바 UI")]
    [SerializeField] TextMeshProUGUI turretDestroyCountText;
    [SerializeField] TextMeshProUGUI killDeathCountText;
    [SerializeField] TextMeshProUGUI minionKillCountText;
    [SerializeField] TextMeshProUGUI timerText;

    [Header("적 챔피언 UI")]
    [SerializeField] TextMeshProUGUI[] enemyStatsText;
    [SerializeField] Image enemyInfoImg; // 적 챔피언 마우스 클릭 시 SetActive(true);
    [SerializeField] Image enemyProfile;
    [SerializeField] GameObject enemyInven;
    [SerializeField] TextMeshProUGUI enemyLevelText;


    [Header("내 챔피언 UI")]
    [SerializeField] TextMeshProUGUI[] myStatsText;
    [SerializeField] Image myProfile;
    [SerializeField] TextMeshProUGUI myLevelText;
    [SerializeField] GameObject myInven;

    private void Update()
    {
       ShowTimer();
    }

    /// <summary>
    /// 상단바에 타이머 표시
    /// </summary>
    private void ShowTimer()
    {
        timerText.text = $"{((int)(GameManager.instance.PlayTime / 60)).ToString()}" + " : " + ((int)(GameManager.instance.PlayTime % 60)).ToString();
    }
}
