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
        SetInputButton();
    }

    private void SetInputButton()
    {
        if (IsPressed(BUTTON.Q_BTN)) invoker.ExecuteCommand(btnQ);
        else if (IsPressed(BUTTON.W_BTN)) invoker.ExecuteCommand(btnW);
        else if (IsPressed(BUTTON.E_BTN)) invoker.ExecuteCommand(btnE);
        else if (IsPressed(BUTTON.R_BTN)) invoker.ExecuteCommand(btnR);
        else if (IsPressed(BUTTON.D_BTN)) invoker.ExecuteCommand(btnD);
        else if (IsPressed(BUTTON.F_BTN)) invoker.ExecuteCommand(btnF);
        else if (IsPressed(BUTTON.A_BTN)) invoker.ExecuteCommand(btnA);
    }

    
    bool IsPressed(BUTTON button)
    {
        pressedBtn = button;
        if (Input.GetKey(KeyCode.Q))
            pressedBtn = BUTTON.Q_BTN;
        else if(Input.GetKey(KeyCode.W))
            pressedBtn = BUTTON.W_BTN;
        else if (Input.GetKey(KeyCode.E))
            pressedBtn = BUTTON.E_BTN;
        else if (Input.GetKey(KeyCode.R))
            pressedBtn = BUTTON.R_BTN;
        else if (Input.GetKey(KeyCode.D))
            pressedBtn = BUTTON.D_BTN;
        else if (Input.GetKey(KeyCode.F))
            pressedBtn = BUTTON.F_BTN;
        else if (Input.GetKey(KeyCode.A))
            pressedBtn = BUTTON.A_BTN;

        return (button == pressedBtn);
    }
}
