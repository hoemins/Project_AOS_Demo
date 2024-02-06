using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopUI : MonoBehaviour
{
    [SerializeField] List<ShopItemSlotList> shopSlotList; 
    [SerializeField] ShopItemSlot selectedSlot;


    public void SelectSlot(ShopItemSlot slot)
    {
        selectedSlot.ItemData = slot.ItemData;
        selectedSlot.SetSlot(selectedSlot.ItemData);
    }

    public void SellItem(Champion player)
    {
        player.TryBuyItem(selectedSlot.ItemData);
    }
}
