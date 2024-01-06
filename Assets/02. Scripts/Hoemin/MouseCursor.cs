using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorImg;
    void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }

    
}
