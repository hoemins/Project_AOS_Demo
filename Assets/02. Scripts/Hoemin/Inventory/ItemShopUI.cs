using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopUI : MonoBehaviour
{
    [SerializeField] List<ShopItemSlotList> shopSlotList; 
    [SerializeField] ShopItemSlot selectedSlot;
    [SerializeField] AudioClip purchaseClip;
    [SerializeField] AudioClip sellClip;
    public void SelectSlot(ShopItemSlot slot)
    {
        selectedSlot.ItemData = slot.ItemData;
        selectedSlot.SetSlot(selectedSlot.ItemData);
    }

    public void SellItem(Champion player)
    {
        if (player.TryBuyItem(selectedSlot.ItemData))
        {
            SoundManager.instance.Play(purchaseClip);
        }
    }
}
