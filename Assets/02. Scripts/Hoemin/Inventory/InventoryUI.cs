using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] List<InvenItemSlot> invenItemSlots = null;
    [SerializeField] private int gold;
    public event Action onValueChange;
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            if (gold <= 0) gold = 0;
            gold = value;
        }
    }


    public void AddItem(ItemDataSO item)
    {
        for (int i = 0; i < invenItemSlots.Count; i++)
        {
            if (invenItemSlots[i].ItemData == null)
            {
                invenItemSlots[i].SetSlot(item);
                onValueChange?.Invoke();
                return;
            }
        }
    }
    public void RemoveItem()
    {
        foreach(InvenItemSlot slot in invenItemSlots)
        {
            if(slot.IsSeleted == true)
            {
                gold += (int)(slot.ItemData.buyPrice * 0.7);
                onValueChange?.Invoke();
                slot.ItemImg.sprite = null;
                slot.ItemData = null;
            }
        }
    }

    public void SelectSlot(int index)
    {
        if (invenItemSlots[index].ItemData == null)
            return;
        foreach(InvenItemSlot slot in invenItemSlots)
        {
            slot.IsSeleted = false;
        }
        invenItemSlots[index].IsSeleted = true;
    }

}
