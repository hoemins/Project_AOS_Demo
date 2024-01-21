using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour, IPointerEnterHandler
{
    MouseCursor cursor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name);
    }
}
