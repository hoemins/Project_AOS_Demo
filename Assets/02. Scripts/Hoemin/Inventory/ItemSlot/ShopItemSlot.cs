using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : ItemSlot
{
    private TextMeshProUGUI priceTxt;


    public override void InitSlot()
    {
        itemImg = GetComponentInChildren<Image>();
        priceTxt = GetComponentInChildren<TextMeshProUGUI>();
    }


    public override void SetSlot(ItemDataSO item)
    {
        itemImg.sprite = item.itemImg;
        priceTxt.text = item.buyPrice.ToString();
    }


}
