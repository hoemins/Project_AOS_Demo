using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Item item;

    public Item Item { get { return item; } }

    public void SetItem(Item item)
    {
        this.item = item;
        itemImage.sprite = item.Data.itemImg;
    }
    
}
