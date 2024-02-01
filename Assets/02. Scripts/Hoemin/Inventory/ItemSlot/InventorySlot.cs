using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : ItemSlot
{
    [SerializeField] protected Image nonItemImage;
    public override void InitShopSlot()
    {
        throw new System.NotImplementedException();
    }

    public override void SetItem(ItemDataSO item)
    {
        itemImage.sprite = item.itemImg;
        
    }
}
