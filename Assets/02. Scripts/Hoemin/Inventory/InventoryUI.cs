using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] InvenItemSlot[] invenItemSlots = null;
    [SerializeField] TextMeshProUGUI goldTxt;

    public void AddItem(ItemDataSO item)
    {
        for (int i = 0; i < invenItemSlots.Length; i++)
        {
            if (invenItemSlots[i].ItemData == null)
            {
                invenItemSlots[i].SetSlot(item);
                return;
            }
        }
    }
}
