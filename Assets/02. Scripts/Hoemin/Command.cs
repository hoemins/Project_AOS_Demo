using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hoemin
{
    /*
     [To do]
    1. IndicatorRenderer Ŭ������ ����� Skill Ŭ������ �̸� �����ϵ��� ����� 
        ��ų ��� Ŭ�������� Skill Ŭ�������� �����ϵ��� �� ��.
    2. ��ų ���� �� �߻�, A Ű ���� �� �����ϴ� ��� ����
    3. Undo �޼���� ��ų ��� Ŭ�������� �����ϰ��ִ� Skill Ŭ��������
        DrawIndicator ���� �׷��� ���ؼ��� ����� �޼��带 ȣ��
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

