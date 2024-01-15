using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Hoemin
{
    /*
     [To do]
    1. IndicatorRenderer Ŭ������ ����� Skill Ŭ������ �̸� �����ϵ��� ����� 
        ��ų ��� Ŭ�������� Skill Ŭ�������� �����ϵ��� �� ��.
    2. ��ų ���� �� �߻�, A Ű ���� �� �����ϴ� ��� ����
    3. Undo �޼���� ��ų ��� Ŭ�������� �����ϰ��ִ� Skill Ŭ��������
        IndicatorRenderer ���� �׷��� ���ؼ��� ����� �޼��带 ȣ��
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
    /// ��ų ��ư�� ������ �� ��ų ���ؼ��� �Ѵ� ���
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
    /// ��ų �ߵ� ���
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

    /// <summary>
    /// ���� ��� 
    /// </summary>
    public class AttackCommand : ICommand
    {
        private IndicatorRenderer indicatorRenderer;
        private INDICATOR_ENUM indicatorEnum;
        private Champion owner;

        // ���콺 ��Ŭ���� ������ �ٷ� �Ͽ� ���� ���·� �ٷ� ��ȯ �� �� ������ Ŀ�ǵ� 
        public AttackCommand(Champion owner)
        {
            this.owner = owner;
        }

        // ���� ��ư(A)�� ������ ���� �� �������� Ŀ�ǵ�
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

