using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;
    ItemSlot[] itemSlots = null;

    private void Start()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>();
    }


    public void AddItem(ItemDataSO newItem)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].ItemData == null)
            {
                itemSlots[i].SetItem(newItem);
                return;
            }
        }
    }


}
