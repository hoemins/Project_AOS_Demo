using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 커맨드 패턴 테스트
/// </summary>
namespace Hoemin
{
    public interface Command
    {
        void Execute();
    }

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


    public class Player : MonoBehaviour
    {
        public enum SKILL_BTN
        { Q_BTN, W_BTN, E_BTN, R_BTN, NONE }

        SKILL_BTN pressedBTN = SKILL_BTN.NONE;
        Command btnQ;
        // Update is called once per frame
        void Update()
        {
            if (IsPressed(SKILL_BTN.Q_BTN))
                btnQ.Execute();
            else if (IsPressed(SKILL_BTN.W_BTN)) FireWSkill();
            else if (IsPressed(SKILL_BTN.E_BTN)) FireESkill();
            else if (IsPressed(SKILL_BTN.R_BTN)) FireRSkill();

        }

        

        void FireWSkill()
        {
            Debug.Log("WSkill");
        }

        void FireESkill()
        {
            Debug.Log("ESkill");
        }

        void FireRSkill()
        {
            Debug.Log("RSkill");
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

