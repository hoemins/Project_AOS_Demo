using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Champion owner;
    [SerializeField] TextMeshProUGUI goldText;
    ItemSlot[] itemSlots = null;

    private void Start()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>();
    }

    public void AddItem(Item newItem)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                itemSlots[i].SetItem(newItem);
                return;
            }
        }
    }


}
