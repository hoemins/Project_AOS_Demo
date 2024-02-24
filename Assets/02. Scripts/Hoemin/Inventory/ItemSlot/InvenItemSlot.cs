using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenItemSlot : ItemSlot
{
    [SerializeField] private bool isSelected = false;

    public bool IsSeleted
    {
        get { return isSelected; }
        set { isSelected = value; }
    }

    public override void InitSlot()
    {
        itemImg = GetComponentInChildren<Image>();
    }

    public override void SetSlot(ItemDataSO item)
    {
        itemImg.sprite = item.itemImg;
        itemData = item;
    }
}
