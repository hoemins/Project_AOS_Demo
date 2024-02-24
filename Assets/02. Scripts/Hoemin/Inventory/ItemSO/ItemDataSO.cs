using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM_RANK
{
    Basic, Epic, Unique
}

[CreateAssetMenu]
public class ItemDataSO : ScriptableObject
{

    public ITEM_RANK rank;
    public Sprite itemImg;
    public string itemName;
    public int buyPrice;


    
}
