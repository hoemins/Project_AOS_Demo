using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItemSlotList : MonoBehaviour
{
    [SerializeField] private List<ShopItemSlot> shopItemSlotList;
    [SerializeField] TextMeshProUGUI rankTxt;

    private void Start()
    {
        SetShopItem();
    }

    public void SetShopItem()
    {
        for (int i = 0; i < shopItemSlotList.Count; i++)
        {
            shopItemSlotList[i].SetSlot(shopItemSlotList[i].ItemData);
        }
    }

}
