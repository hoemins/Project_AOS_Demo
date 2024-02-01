using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ItemSlot : MonoBehaviour
{
    [SerializeField] protected Image itemImage;
    [SerializeField] protected ItemDataSO itemData;

    public ItemDataSO ItemData { get { return itemData; } set { itemData = value; } }
    
    public abstract void InitShopSlot();


    public abstract void SetItem(ItemDataSO item);


}
