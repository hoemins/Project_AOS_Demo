using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Hoemin
{
    /// <summary>
    /// 적절한 객체나 현 상태에 따른 마우스 커서 저장 (Test 버전임)
    /// </summary>
    public class MouseCursor : MonoBehaviour
    {
        [SerializeField] Texture2D arrowImg;
        [SerializeField] Texture2D swordImg;

        void Start()
        {
            Cursor.SetCursor(arrowImg, Vector2.zero, CursorMode.ForceSoftware);
        }

        
    }
}

