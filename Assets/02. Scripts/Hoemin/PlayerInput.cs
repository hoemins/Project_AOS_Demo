using Hoemin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private ICommand qSkillCommand;
    private ICommand wSkillCommand;
    private ICommand eSkillCommand;
    private ICommand rSkillCommand;

    public void Awake()
    {
        Camera.main.ScreenPointToRay(Vector3Int.left);
    }

}
