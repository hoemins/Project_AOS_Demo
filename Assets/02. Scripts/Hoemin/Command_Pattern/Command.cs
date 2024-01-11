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
    public enum SkillType
    {
        DIRECT,
        WAIT,
    }

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
            owner.CurUseSkill = owner.Champion.SkillList[(int)BUTTON.Q_BTN];
        }

        public void Undo()
        {
            owner.CurUseSkill = null;
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
            owner.CurUseSkill = owner.Champion.SkillList[(int)BUTTON.W_BTN];
        }

        public void Undo()
        {
            owner.CurUseSkill = null;
        }
    }

    public class ESkillCommand : ICommand
    {
        private PlayerInput owner;

        public ESkillCommand(PlayerInput owner)
        {
            this.owner = owner;
        }

        public void Execute()
        {
            owner.CurUseSkill = owner.Champion.SkillList[(int)BUTTON.E_BTN];
        }

        public void Undo()
        {
            owner.CurUseSkill = null;
        }
    }

    public class RSkillCommand : ICommand
    {
        private PlayerInput owner;

        public RSkillCommand(PlayerInput owner)
        {
            this.owner = owner;
        }

        public void Execute()
        {
            owner.CurUseSkill = owner.Champion.SkillList[(int)BUTTON.R_BTN];
        }

        public void Undo()
        {
            owner.CurUseSkill = null;
        }
    }

    public class DSpellCommand : ICommand
    {
        private PlayerInput owner;

        public DSpellCommand(PlayerInput owner)
        {
            this.owner = owner;
        }

        public void Execute()
        {
            owner.CurUseSkill = owner.Champion.SkillList[(int)BUTTON.D_BTN];
        }

        public void Undo()
        {
            owner.CurUseSkill = null;
        }
    }

    public class FSpellCommand : ICommand
    {
        private PlayerInput owner;

        public FSpellCommand(PlayerInput owner)
        {
            this.owner = owner;
        }

        public void Execute()
        {
            owner.CurUseSkill = owner.Champion.SkillList[(int)BUTTON.R_BTN];
        }

        public void Undo()
        {
            owner.CurUseSkill = null;
        }
    }

}

