using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("��ܹ� UI")]
    [SerializeField] TextMeshProUGUI turretDestroyCountText;
    [SerializeField] TextMeshProUGUI killDeathCountText;
    [SerializeField] TextMeshProUGUI minionKillCountText;
    [SerializeField] TextMeshProUGUI timerText;

    [Header("�� è�Ǿ� UI")]
    [SerializeField] TextMeshProUGUI[] enemyStatsText;
    [SerializeField] Image enemyInfoImg; // �� è�Ǿ� ���콺 Ŭ�� �� SetActive(true);
    [SerializeField] Image enemyProfile;
    [SerializeField] GameObject enemyInven;
    [SerializeField] TextMeshProUGUI enemyLevelText;


    [Header("�� è�Ǿ� UI")]
    [SerializeField] TextMeshProUGUI[] myStatsText;
    [SerializeField] Image myProfile;
    [SerializeField] TextMeshProUGUI myLevelText;
    [SerializeField] GameObject myInven;

    private void Update()
    {
       ShowTimer();
    }

    /// <summary>
    /// ��ܹٿ� Ÿ�̸� ǥ��
    /// </summary>
    private void ShowTimer()
    {
        timerText.text = $"{((int)(GameManager.instance.PlayTime / 60)).ToString()}" + " : " + ((int)(GameManager.instance.PlayTime % 60)).ToString();
    }
}
