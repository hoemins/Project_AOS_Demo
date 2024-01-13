using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 커맨드 패턴의 Receiver 클래스 (이전 : PlayerInput)
public class CommandInputManager : MonoBehaviour
{
    [SerializeField] IndicatorRenderer indicatorRenderer;
    [SerializeField] Champion champion;
    CommandInvoker invoker;


    private void Start()
    {
        invoker = new CommandInvoker();
    }

    private void Update()
    {
        // 키를 바꾸고 싶다면? Champion이 가진 SkillList 의 순서만 변경해주면 됨
        PresseSkillCommandKey(KeyCode.Q, 0);
        PresseSkillCommandKey(KeyCode.W, 1);
        PresseSkillCommandKey(KeyCode.E, 2);
        PresseSkillCommandKey(KeyCode.R, 3);
        PresseAttackCommandKey();
    }

    private void PresseSkillCommandKey(KeyCode key, int index)
    {
        if (Input.GetKey(key))
        {
            ICommand onSpaceSkill = new OnSkillCommand(indicatorRenderer);
            invoker.ExecuteCommand(onSpaceSkill);
            if (Input.GetMouseButtonDown(0))
            {
                Skill spaceSkill = champion.GetSkill(index);
                ICommand useSpaceSkill = new InvokeSkillCommand(spaceSkill);
                invoker.ExecuteCommand(useSpaceSkill);

            }
            if (Input.GetMouseButtonDown(1))
            {
                invoker.UndoCommand();

            }
        }
    }

    private void PresseAttackCommandKey()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ICommand aimAttackCommand = new AttackCommand(indicatorRenderer, champion);
            invoker.ExecuteCommand(aimAttackCommand);
            if(Input.GetMouseButtonDown(0))
            {
                ICommand attackCommand = new AttackCommand(champion);
                invoker.ExecuteCommand(attackCommand);
            }
        }
    }
    
}
