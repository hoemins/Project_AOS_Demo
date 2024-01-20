using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private GameObject eftPrefab;
    Champion owner;
    DetectComponent detectComponent;
    IEnumerator attackDelayCor;
    IEnumerator attackStartDelayCor;

    public List<Collider> targetCols;


    private void Start()
    {
        detectComponent = GetComponent<DetectComponent>();
        owner = GetComponent<Champion>();
        targetCols = new List<Collider>();
        attackStartDelayCor = AttackStartCor();
    }

    private void Update()
    {
        if(detectComponent != null)
        {
            if(detectComponent.IsDetected == true)
            {
                Attack();
            }
        }
    }


    public void Attack()
    {
        if (attackDelayCor == null)
        {
            StartCoroutine(attackStartDelayCor);
            attackDelayCor = AttackDelayCor();
            StartCoroutine(attackDelayCor);
        }
    }

    IEnumerator AttackStartCor()
    {
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator AttackDelayCor()
    {
        owner.Anim.Play("Attack");
        owner.MoveController.Agent.isStopped = true;
        owner.MoveController.Agent.ResetPath();
        if (eftPrefab != null)
            eftPrefab.SetActive(true);

        for (int i = 0; i<detectComponent.Colliders.Length; i++)
        {
            targetCols.Add(detectComponent.Colliders[i]);
        }
        yield return new WaitForSeconds(owner.ChampionInfo.PhysicalAtkDelay);
        attackDelayCor = null;
        owner.MoveController.Agent.isStopped = false;
        targetCols.Clear();
    }
}
