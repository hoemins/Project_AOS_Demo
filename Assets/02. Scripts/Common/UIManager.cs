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
    [SerializeField] InventoryUI enemyInven;
    [SerializeField] TextMeshProUGUI enemyLevelText;


    [Header("내 챔피언 UI")]
    [SerializeField] Champion myChampion;
    [SerializeField] TextMeshProUGUI[] myStatsText;
    [SerializeField] Image myProfile;
    [SerializeField] TextMeshProUGUI myLevelText;
    [SerializeField] InventoryUI myInven;
    [SerializeField] TextMeshProUGUI myMoneyText;
    [SerializeField] SkillSlot[] skillSlots;
    [SerializeField] Canvas levelUpTxtCanvas;

    public override void Awake()
    {
        base.Awake();
        InitChampionStats();
        myChampion.onLevelup += () =>
        {
            for (int i = 0; skillSlots.Length > 0; i++)
            {
                if (myChampion.ChampionInfo.Level >= skillSlots[i].skill.Data.requiredLevel)
                    skillSlots[i].enableLevelUpImg.gameObject.SetActive(true);
                else
                    skillSlots[i].disabledLevelUpImg.gameObject.SetActive(true);
            }
            
        };

        
    }

    

    private void Update()
    {
       ShowTimer();
    }

    /// <summary>
    /// 상단바에 타이머 표시, stringBulider 를 써야할까?
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
        myStatsText[4].text = (myChampion.ChampionInfo.PhysicalAtkDelay*10).ToString();
        myStatsText[5].text = (myChampion.ChampionInfo.CriticalChance*100).ToString();
        myStatsText[6].text = myChampion.ChampionInfo.AbilityHaste.ToString();
        myStatsText[7].text = (myChampion.ChampionInfo.MoveSpeed*10).ToString();

        myProfile.sprite = myChampion.ChampionInfo.ProfileImg;
        myLevelText.text = myChampion.ChampionInfo.Level.ToString();
        levelUpTxtCanvas.gameObject.SetActive(false);
    }
   

    public void OnSkillLevelUpButtonClick()
    {
        myChampion.skillPoint--;
        for (int i = 0; skillSlots.Length > 0; i++)
        {
            skillSlots[i].enableLevelUpImg.gameObject.SetActive(false);
            skillSlots[i].disabledLevelUpImg.gameObject.SetActive(false);
                
        }
    }

}
