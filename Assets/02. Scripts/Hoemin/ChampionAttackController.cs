using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionAttackController : MonoBehaviour, IAttackable
{
    Champion champion;

    private void Start()
    {
        champion = GetComponent<Champion>();
    }

    public void Attack()
    {
        Debug.Log("기본 공격 발싸");
    }

}
