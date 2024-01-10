using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    // 게임 진행 시간
    [SerializeField] private float playTime = 0f;
    public float PlayTime { get { return playTime; } private set { playTime = value; } }
    

    public void Update()
    {
        // To Do:
        // - 시간 변수를 사용하여 미니언 출현 주기 생성
        PlayTime += Time.deltaTime;
    }

    
}
