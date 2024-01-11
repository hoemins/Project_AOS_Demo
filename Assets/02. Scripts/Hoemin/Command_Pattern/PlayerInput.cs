using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.PlayerLoop;

public enum BUTTON
{
    Q_BTN, W_BTN, E_BTN, R_BTN, D_BTN, F_BTN, A_BTN, NONE
}

// 커맨드 패턴의 Receiver 클래스
public class PlayerInput : MonoBehaviour
{
    [SerializeField] Champion champion;
    CommandInvoker invoker;
    BUTTON pressedBtn = BUTTON.NONE;
    ICommand btnQ, btnW, btnE, btnR, btnD, btnF, btnA;

    public Champion Champion { get { return champion; } }
    private Skill curUseSkill;
    private bool waitForUseSkill;

    public Skill CurUseSkill
    {
        get => curUseSkill;
        set
        {
            curUseSkill = value;
            if(curUseSkill == null)
            {
                waitForUseSkill = false;
                Debug.Log(waitForUseSkill);
                return;
            }

            if (curUseSkill.skillType == SkillType.DIRECT)
                UseSkill();
            else
            {
                waitForUseSkill = true;
                Debug.Log(waitForUseSkill);
            }
        }
    }

    private void Start()
    {
        Init();   
    }

    private void Update()
    {
        SetInputButton();

        if (waitForUseSkill)
        {
            if (Input.GetMouseButtonDown(0))
                UseSkill();

            if (Input.GetMouseButtonDown(1))
                invoker.UndoCommand();
        }
    }

    private void Init()
    {
        champion = GetComponent<Champion>();
        invoker = new CommandInvoker();
        btnQ = new QSkillCommand(this);
        btnW = new WSkillCommand(this);
        btnE = new ESkillCommand(this);
        btnR = new RSkillCommand(this);
        btnD = new DSpellCommand(this);
        btnF = new FSpellCommand(this);
    }


    public void SetInputButton()
    {

        if (IsPressed(BUTTON.Q_BTN))
        {
            invoker.ExecuteCommand(btnQ);
            pressedBtn = BUTTON.NONE;
        }
        else if (IsPressed(BUTTON.W_BTN))
        {
            invoker.ExecuteCommand(btnW);
            pressedBtn = BUTTON.NONE;
        }
        else if (IsPressed(BUTTON.E_BTN))
        {
            invoker.ExecuteCommand(btnE);
            pressedBtn = BUTTON.NONE;
        }
        else if (IsPressed(BUTTON.R_BTN))
        {
            invoker.ExecuteCommand(btnR);
            pressedBtn = BUTTON.NONE;
        }
        else if (IsPressed(BUTTON.D_BTN))
        {
            invoker.ExecuteCommand(btnD);
            pressedBtn = BUTTON.NONE;
        }
        else if (IsPressed(BUTTON.F_BTN))
        {
            invoker.ExecuteCommand(btnF);
            pressedBtn = BUTTON.NONE;
        }
        // 공격 버튼은 다른 클래스에서 인보커호출 해야할듯?
        else if (IsPressed(BUTTON.A_BTN))
        {
            invoker.ExecuteCommand(btnA);
            pressedBtn = BUTTON.NONE;
        }
    }

    void UseSkill()
    {
        curUseSkill?.Fire();
        Debug.Log("UseSkill");
        waitForUseSkill = false;
        CurUseSkill = null;
    }

    
    public bool IsPressed(BUTTON button)
    {
        if (Input.GetKeyDown(KeyCode.Q))
            pressedBtn = BUTTON.Q_BTN;
        else if(Input.GetKeyDown(KeyCode.W))
            pressedBtn = BUTTON.W_BTN;
        else if (Input.GetKeyDown(KeyCode.E))
            pressedBtn = BUTTON.E_BTN;
        else if (Input.GetKeyDown(KeyCode.R))
            pressedBtn = BUTTON.R_BTN;
        else if (Input.GetKeyDown(KeyCode.D))
            pressedBtn = BUTTON.D_BTN;
        else if (Input.GetKeyDown(KeyCode.F))
            pressedBtn = BUTTON.F_BTN;
        else if (Input.GetKeyDown(KeyCode.A))
            pressedBtn = BUTTON.A_BTN;

        return (button == pressedBtn);
    }
}
