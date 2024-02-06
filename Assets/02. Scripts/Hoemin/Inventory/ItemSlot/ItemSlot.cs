using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemSlot : MonoBehaviour
{
    [SerializeField] protected Image itemImg;
    [SerializeField] protected ItemDataSO itemData;
    public ItemDataSO ItemData { get { return itemData; } set { itemData = value; } }
    public Image ItemImg { get { return itemImg; } set { itemImg = value; } }

    private void Awake()
    {
        InitSlot();
    }

    public abstract void InitSlot();
    public abstract void SetSlot(ItemDataSO item);
}
