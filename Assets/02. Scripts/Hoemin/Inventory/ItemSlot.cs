using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI priceTxt;
    [SerializeField] private ItemDataSO item;

    public ItemDataSO Item { get { return item; } }

    private void Start()
    {
        itemImage.sprite = item.itemImg;
        priceTxt.text = item.price.ToString();
    }

    public void SetItem(ItemDataSO item)
    {
        this.item = item;
        itemImage.sprite = item.itemImg;
    }
    
}
