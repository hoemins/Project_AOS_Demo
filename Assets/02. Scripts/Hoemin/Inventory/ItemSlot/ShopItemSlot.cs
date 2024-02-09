using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : ItemSlot
{
    [SerializeField] private TextMeshProUGUI priceTxt;
    [SerializeField] private TextMeshProUGUI itemNameTxt;


    public override void InitSlot()
    {
        itemImg = GetComponentInChildren<Image>();
    }


    public override void SetSlot(ItemDataSO item)
    {
        itemImg.sprite = item.itemImg;
        priceTxt.text = item.buyPrice.ToString();
        if(itemNameTxt != null )
        {
            itemNameTxt.text = item.itemName;
        }
    }


}
