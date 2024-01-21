using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Hoemin
{
    /// <summary>
    /// ������ ��ü�� �� ���¿� ���� ���콺 Ŀ�� ���� (Test ������)
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

