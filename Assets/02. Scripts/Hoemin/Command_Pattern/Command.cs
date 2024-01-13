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

    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }

    /// <summary>
    /// ��ų ��ư�� ������ �� ��ų ���ؼ��� ���� Ŀ�ǵ� Ŭ����
    /// </summary>
    public class OnSkillCommand : ICommand
    {
        private IndicatorRenderer indicatorRenderer;

        public OnSkillCommand(IndicatorRenderer indicatorRenderer)
        {
            this.indicatorRenderer = indicatorRenderer;
        }

        public void Execute()
        {
            indicatorRenderer.DrawIndicator();
        }

        public void Undo()
        {
            indicatorRenderer.EraseIndicator();
        }
    }

    /// <summary>
    /// ��ų �ߵ� Ŀ�ǵ�
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
        private Champion owner;

        // ���콺 ��Ŭ���� ������ �ٷ� �Ͽ� ���� ���·� �ٷ� ��ȯ �� �� ������ Ŀ�ǵ� 
        public AttackCommand(Champion owner)
        {
            this.owner = owner;
        }

        // ���� ��ư(A)�� ������ ���� �� �������� Ŀ�ǵ�
        public AttackCommand(IndicatorRenderer indicatorRenderer, Champion owner)
        {
            this.indicatorRenderer = indicatorRenderer;
            this.owner = owner;
        }

        public void Execute()
        {
            if (indicatorRenderer == null)
                owner.BasicAttack();
            indicatorRenderer?.DrawIndicator();
        }

        public void Undo()
        {
            indicatorRenderer.EraseIndicator();
        }

        public Champion GetOwner()
        {
            return owner;
        }
    }

}

