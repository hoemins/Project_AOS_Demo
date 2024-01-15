using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Hoemin
{
    /*
     [To do]
    1. IndicatorRenderer 클래스를 만들고 Skill 클래스가 이를 의존하도록 만들어 
        스킬 명령 클래스들이 Skill 클래스들을 의존하도록 할 것.
    2. 스킬 조준 및 발사, A 키 누를 시 공격하는 명령 구현
    3. Undo 메서드는 스킬 명령 클래스들이 의존하고있는 Skill 클래스에서
        IndicatorRenderer 내의 그려진 조준선을 지우는 메서드를 호출
     */

    public enum INDICATOR_ENUM
    {
        QSkill,WSkill,ESkill,RSkill,Attack
    }

    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }

    /// <summary>
    /// 스킬 버튼을 눌렀을 때 스킬 조준선을 켜줄 커맨드 클래스
    /// </summary>
    public class OnSkillCommand : ICommand
    {
        private IndicatorRenderer indicatorRenderer;
        private INDICATOR_ENUM indicatorEnum;

        public OnSkillCommand(IndicatorRenderer indicatorRenderer, INDICATOR_ENUM indicatorEnum)
        {
            this.indicatorRenderer = indicatorRenderer;
            this.indicatorEnum = indicatorEnum; 
        }

        public void Execute()
        {
            indicatorRenderer.DrawIndicator((int)indicatorEnum);
        }

        public void Undo()
        {
            indicatorRenderer.EraseIndicator((int)indicatorEnum);
        }
    }

    /// <summary>
    /// 스킬 발동 커맨드
    /// </summary>
    public class InvokeSkillCommand : ICommand
    {
        private Skill skill;

        public InvokeSkillCommand(Skill skill)
        {
            this.skill = skill;
        }

        public void Execute()
        {
            skill.InvokeSkill();
        }

        public void Undo()
        {

        }
    }

    public class AttackCommand : ICommand
    {
        private IndicatorRenderer indicatorRenderer;
        private INDICATOR_ENUM indicatorEnum;
        private Champion owner;

        // 마우스 우클릭을 적에게 바로 하여 공격 상태로 바로 전환 될 때 생성될 커맨드 
        public AttackCommand(Champion owner)
        {
            this.owner = owner;
        }

        // 공격 버튼(A)을 누르고 있을 때 생성해줄 커맨드
        public AttackCommand(IndicatorRenderer indicatorRenderer, Champion owner, INDICATOR_ENUM indicatorEnum)
        {
            this.indicatorRenderer = indicatorRenderer;
            this.owner = owner;
            this.indicatorEnum = indicatorEnum;
        }

        public void Execute()
        {
            if (indicatorRenderer == null)
                owner.BasicAttack();
            indicatorRenderer?.DrawIndicator((int)indicatorEnum);
        }

        public void Undo()
        {
            indicatorRenderer.EraseIndicator((int)indicatorEnum);
        }

        public Champion GetOwner()
        {
            return owner;
        }
    }

}

