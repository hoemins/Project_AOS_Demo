using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public enum ItemListType
    {
        BasicItemList, EpicItemList, UniqueItemList
    }

    public ItemListType type;
    public List<ShopSlot> slotList;

    private void Start()
    {
        for(int i = 0; i < slotList.Count; i++)
        {
            if (slotList[i].ItemData != null)
                slotList[i].SetItem(slotList[i].ItemData);
            else
                slotList[i].gameObject.SetActive(false);
        }
    }
}
