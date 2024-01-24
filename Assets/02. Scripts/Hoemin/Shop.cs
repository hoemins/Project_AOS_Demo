using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ItemShopUI itemShop;
    DetectComponent detectComponent;

    private void Start()
    {
        detectComponent = GetComponent<DetectComponent>();
        itemShop.gameObject.SetActive(false);
    }

    public void OpenShop()
    {
        if (detectComponent.IsDetected)
            itemShop.gameObject.SetActive(true);
    }

    public void ExitShop()
    {
        itemShop.gameObject?.SetActive(false);
    }

    public void SellItem()
    {
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        OpenShop();
    }
}
