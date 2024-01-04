using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    // ���� ���� �ð�
    [SerializeField] private float playTime = 0f;
    public float PlayTime { get { return playTime; } private set { playTime = value; } }
    

    public void Update()
    {
        // To Do:
        // - �ð� ������ ����Ͽ� �̴Ͼ� ���� �ֱ� ����
        PlayTime += Time.deltaTime;
    }
}
