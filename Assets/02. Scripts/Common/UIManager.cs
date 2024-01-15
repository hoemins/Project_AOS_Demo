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
    [SerializeField] Inventory enemyInven;
    [SerializeField] TextMeshProUGUI enemyLevelText;


    [Header("�� è�Ǿ� UI")]
    [SerializeField] Champion myChampion;
    [SerializeField] TextMeshProUGUI[] myStatsText;
    [SerializeField] Image myProfile;
    [SerializeField] TextMeshProUGUI myLevelText;
    [SerializeField] Inventory myInven;
    [SerializeField] TextMeshProUGUI myMoneyText;
    [SerializeField] GameObject[] skillSlots;

    private void Start()
    {
        InitChampionStats();
    }

    private void Update()
    {
       ShowTimer();
    }

    /// <summary>
    /// ��ܹٿ� Ÿ�̸� ǥ��, stringBulider �� ����ұ�?
    /// </summary>
    private void ShowTimer()
    {
        timerText.text = $"{((int)(GameManager.instance.PlayTime / 60)).ToString()}" + " : " + ((int)(GameManager.instance.PlayTime % 60)).ToString();
    }

    private void InitChampionStats()
    {
        myStatsText[0].text = myChampion.ChampionInfo.PhysicalAtk.ToString();
        myStatsText[1].text = myChampion.ChampionInfo.AbilityAtk.ToString();
        myStatsText[2].text = myChampion.ChampionInfo.PhsicalDef.ToString();
        myStatsText[3].text = myChampion.ChampionInfo.MagicalResistance.ToString();
        myStatsText[4].text = myChampion.ChampionInfo.PhysicalAtkDelay.ToString();
        myStatsText[5].text = (myChampion.ChampionInfo.CriticalChance*100).ToString();
        myStatsText[6].text = myChampion.ChampionInfo.AbilityHaste.ToString();
        myStatsText[7].text = (myChampion.ChampionInfo.MoveSpeed*10).ToString();

        myProfile.sprite = myChampion.ChampionInfo.ProfileImg;
        myLevelText.text = myChampion.ChampionInfo.Level.ToString();
        
    }
   

}
