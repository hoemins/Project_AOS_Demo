using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] InvenItemSlot[] invenItemSlots = null;
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
        for (int i = 0; i < invenItemSlots.Length; i++)
        {
            if (invenItemSlots[i].ItemData == null)
            {
                invenItemSlots[i].SetSlot(item);
                onValueChange?.Invoke();
                return;
            }
        }
    }
}
