using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemList : MonoBehaviour
{
    // 리스트에 슬롯의 삽입과 삭제가 빈번할 수 있기에 List 자료구조 사용
    [SerializeField] List<ItemSlot> slotList;

    private void Start()
    {

    }

}
