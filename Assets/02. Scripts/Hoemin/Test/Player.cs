using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 커맨드 패턴 테스트
/// </summary>
namespace Hoemin
{
    // 추상화된 Command
    public interface Command
    {
        void Execute();
    }

    // ConcrateCommand
    public class QskillCommand : Hoemin.Command
    {
        
        public void Execute()
        {
            FireQSkill();
        }

        void FireQSkill()
        {
            Debug.Log("QSkill");
        }
    }

    public class WskillCommand : Hoemin.Command
    {

        public void Execute()
        {
            FireWSkill();
        }

        void FireWSkill()
        {
            Debug.Log("WSkill");
        }
    }
    public class EskillCommand : Hoemin.Command
    {

        public void Execute()
        {
            FireESkill();
        }

        void FireESkill()
        {
            Debug.Log("ESkill");
        }
    }

   
    public class RskillCommand : Hoemin.Command
    {

        public void Execute()
        {
            FireRSkill();
        }

        void FireRSkill()
        {
            Debug.Log("RSkill");
        }
    }


    // invoker 가 없는 상태
    public class Player : MonoBehaviour
    {
        public enum SKILL_BTN
        { Q_BTN, W_BTN, E_BTN, R_BTN, NONE }

        SKILL_BTN pressedBTN = SKILL_BTN.NONE;
        Command btnQ,btnW,btnE,btnR;

        // Update is called once per frame
        void Update()
        {
            if (IsPressed(SKILL_BTN.Q_BTN)) btnQ.Execute();
            else if (IsPressed(SKILL_BTN.W_BTN)) btnW.Execute();
            else if (IsPressed(SKILL_BTN.E_BTN)) btnE.Execute();
            else if (IsPressed(SKILL_BTN.R_BTN)) btnR.Execute();
        }

        bool IsPressed(SKILL_BTN btn)
        {
            pressedBTN = btn;
            if (Input.GetKey(KeyCode.Q))
                pressedBTN = SKILL_BTN.Q_BTN;
            else if (Input.GetKey(KeyCode.W))
                pressedBTN = SKILL_BTN.W_BTN;
            else if (Input.GetKey(KeyCode.E))
                pressedBTN = SKILL_BTN.E_BTN;
            else if (Input.GetKey(KeyCode.R))
                pressedBTN = SKILL_BTN.R_BTN;
            return (btn == pressedBTN);
        }

    }
}

