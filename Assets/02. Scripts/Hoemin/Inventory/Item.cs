using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDataSO data;
    public ItemDataSO Data { get { return data; } }
}