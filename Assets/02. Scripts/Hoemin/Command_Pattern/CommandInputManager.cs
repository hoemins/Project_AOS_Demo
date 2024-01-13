using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 커맨드 패턴의 Receiver 클래스
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
        PresseCommandKey(KeyCode.Q,(int)SKILL_INDEX.Q);
        PresseCommandKey(KeyCode.W, (int)SKILL_INDEX.W);
        PresseCommandKey(KeyCode.E, (int)SKILL_INDEX.E);
        PresseCommandKey(KeyCode.R, (int)SKILL_INDEX.R);
    }

    private void PresseCommandKey(KeyCode key, int index)
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

}
