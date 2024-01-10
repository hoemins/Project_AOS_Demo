using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

// 커맨드 패턴의 Receiver 클래스
public class PlayerInput : MonoBehaviour
{
    public enum BUTTON 
    { 
        Q_BTN, W_BTN, E_BTN, R_BTN, D_BTN, F_BTN, A_BTN, NONE 
    }

    BUTTON pressedBtn = BUTTON.NONE;
    ICommand btnQ, btnW, btnE, btnR, btnD, btnF, btnA;
    CommandInvoker invoker = null;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        invoker = new CommandInvoker();
        btnQ = new QSkillCommand(this);
        btnW = new WSkillCommand(this);
    }

    private void Update()
    {
        if(IsPressed(BUTTON.Q_BTN))
        {
            invoker.AddCommand(btnQ);
        }
        else if (IsPressed(BUTTON.W_BTN))
        {
            invoker.AddCommand(btnW);
        }
    }


    bool IsPressed(BUTTON button)
    {
        pressedBtn = button;
        if (Input.GetKey(KeyCode.Q))
            pressedBtn = BUTTON.Q_BTN;
        if(Input.GetKey(KeyCode.W))
            pressedBtn = BUTTON.W_BTN;


        return (button == pressedBtn);
    }
}
