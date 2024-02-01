using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopUI : MonoBehaviour
{
    [SerializeField] Shop Owner;
    public List<ItemList> lists;
    public ShopSlot choicedSlot;
    private void Start()
    {
        choicedSlot.onSelect += ChoiceSlot;
    }

    public void ChoiceSlot(ShopSlot slot)
    {
        choicedSlot = slot;
    }
}
