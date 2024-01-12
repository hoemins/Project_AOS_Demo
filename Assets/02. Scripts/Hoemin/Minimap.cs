using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject worldMap;
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnMinimapClick()
    {
        Vector2 mouseClickPosition = Input.mousePosition;
        Vector2 clickedPosition = mouseClickPosition - rectTransform.offsetMin;
        Vector2 ratioVector = clickedPosition / rectTransform.rect.size;

        Vector3 worldMapPosition;
        worldMapPosition.x = ratioVector.x * 1920;
        worldMapPosition.z = ratioVector.y * 1080;
        worldMapPosition.y = 0;

        mainCam.transform.position = worldMapPosition;
    }
}
