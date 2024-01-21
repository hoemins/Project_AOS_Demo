using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionAttackController : MonoBehaviour, IAttackable
{
    [SerializeField] private GameObject eftPrefab;
    AutoAttack autoAttack;
    Champion owner;

    public AutoAttack AutoAttack { get { return autoAttack; } }
    
    private void Start()
    {
        owner = GetComponent<Champion>();
        autoAttack = GetComponent<AutoAttack>();
    }

    public void Attack()
    {
        owner.StateMachine.SetState((int)CHAMPION_STATE.ATTACK);
    }



}
