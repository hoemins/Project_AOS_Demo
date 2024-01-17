using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Hoemin
{
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
    /// 스킬 버튼을 눌렀을 때 스킬 조준선을 켜는 명령
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
    /// 스킬 발동 명령
    /// </summary>
    public class InvokeSkillCommand : ICommand
    {
        private Skill skill;
        private IndicatorRenderer renderer;
        private INDICATOR_ENUM indicatorEnum;
        public InvokeSkillCommand(Skill skill, IndicatorRenderer renderer, INDICATOR_ENUM indicatorEnum)
        {
            this.skill = skill;
            this.renderer = renderer;
            this.indicatorEnum = indicatorEnum;
        }

        public void Execute()
        {
            skill.InvokeSkill();
            renderer.EraseIndicator((int)indicatorEnum);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 공격 명령 
    /// </summary>
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
                owner.AttackController.Attack();
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

