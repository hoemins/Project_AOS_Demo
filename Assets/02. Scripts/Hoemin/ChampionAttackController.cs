using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampionAttackController : MonoBehaviour, IAttackable
{
    [SerializeField] private GameObject eftPrefab;
    [SerializeField] AutoAttack autoAttack;
    [SerializeField] Champion owner;

    
    private void Start()
    {
        owner = GetComponent<Champion>();
        autoAttack = GetComponent<AutoAttack>();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }



}
