using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopSlot : ItemSlot, IPointerClickHandler
{
    [SerializeField] protected TextMeshProUGUI priceTxt;
    public event Action<ShopSlot> onSelect;

    public Image ItemImage { get; set; }
    public override void InitShopSlot()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onSelect.Invoke(this);
    }

    public override void SetItem(ItemDataSO item)
    {
        itemImage.sprite = item.itemImg;
        priceTxt.text = item.buyPrice.ToString();
    }
}
