using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoemin
{
    /*
     [To do]
    1. IndicatorRenderer 클래스를 만들고 Skill 클래스가 이를 의존하도록 만들어 
        스킬 명령 클래스들이 Skill 클래스들을 의존하도록 할 것.
    2. 스킬 조준 및 발사, A 키 누를 시 공격하는 명령 구현
    3. Undo 메서드는 스킬 명령 클래스들이 의존하고있는 Skill 클래스에서
        DrawIndicator 내의 그려진 조준선을 지우는 메서드를 호출
     */

    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }
    
    public class QSkillCommand : ICommand
    {
        private PlayerInput owner;

        public QSkillCommand(PlayerInput owner)
        {
            this.owner = owner;
        }

        public void Execute()
        {
            Debug.Log("QSKillCommand Execute");
        }

        public void Undo()
        {
            
        }
    }

    public class WSkillCommand : ICommand
    {
        private PlayerInput owner;

        public WSkillCommand(PlayerInput owner)
        {
            this.owner = owner;
        }

        public void Execute()
        {
            Debug.Log("WSKillCommand Execute");
        }

        public void Undo()
        {

        }
    }

}

