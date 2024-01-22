using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDataSO : ScriptableObject
{
    public Sprite itemImg;
    public string itemName;
    public string rank;
    public int price;
}
