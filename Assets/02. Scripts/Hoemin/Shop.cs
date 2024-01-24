using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour, IPointerClickHandler
{
    MouseCursor cursor;
    [SerializeField] Canvas shopCanvas;
    DetectComponent detectComponent;

    private void Start()
    {
        detectComponent = GetComponent<DetectComponent>();
        shopCanvas.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(detectComponent.IsDetected)
            shopCanvas.gameObject.SetActive(true);
    }
}
