using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI priceTxt;
    [SerializeField] private ItemDataSO itemData;
    [SerializeField] private ChoicedItemSlot choicedItem;

    public ItemDataSO ItemData { get { return itemData; } }

    private void Start()
    {
        InitSlot();
    }

    private void InitSlot()
    {
        if (itemImage != null)
        {
            itemImage.sprite = itemData.itemImg;
        }

        if (priceTxt != null)
        {
            priceTxt.text = itemData.buyPrice.ToString();
        }
    }

    public void SetItem(ItemDataSO item)
    {
        this.itemData = item;
        itemImage.sprite = item.itemImg;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        choicedItem.itemImage.sprite = this.itemImage.sprite;
        choicedItem.itemName.text = itemData.itemName;
        choicedItem.priceTxt.text = itemData.buyPrice.ToString();
    }
}
