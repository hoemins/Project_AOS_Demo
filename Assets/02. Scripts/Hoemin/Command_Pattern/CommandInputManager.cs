using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ŀ�ǵ� ������ Receiver Ŭ���� (���� : PlayerInput)
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
        // Ű�� �ٲٰ� �ʹٸ�? Champion�� ���� SkillList �� ������ �������ָ� ��
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
            ICommand onSkill = new OnSkillCommand(indicatorRenderer, (INDICATOR_ENUM)index);
            invoker.ExecuteCommand(onSkill);
            
            if (Input.GetMouseButtonDown(0))
            {
                Skill curskill = champion.GetSkill(index);
                ICommand useSkill = new InvokeSkillCommand(curskill,indicatorRenderer,(INDICATOR_ENUM)index);
                invoker.ExecuteCommand(useSkill);
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
            ICommand aimAttackCommand = new AttackCommand(indicatorRenderer, champion, INDICATOR_ENUM.Attack);
            invoker.ExecuteCommand(aimAttackCommand);
            if(Input.GetMouseButtonDown(0))
            {
                ICommand attackCommand = new AttackCommand(champion);
                invoker.ExecuteCommand(attackCommand);
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            invoker.UndoCommand();
        }
    }
    
}
