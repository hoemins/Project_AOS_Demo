using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionAttackController : MonoBehaviour, IAttackable
{
    Champion champion;
    IHitable target;

    private void Start()
    {
        champion = GetComponent<Champion>();
    }

    public void Attack()
    {
        
        Debug.Log("�⺻ ���� �߽�");
    }

}
