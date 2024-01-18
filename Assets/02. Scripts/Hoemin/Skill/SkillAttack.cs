using Hoemin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] GameObject skillObject;
    SkillEffectController skillEffectController;
    private Champion owner;

    private void Start()
    {
        owner = GetComponentInParent<Champion>();
        skillEffectController = skillObject.GetComponent<SkillEffectController>();

        skillEffectController.atkAction += (IHitable target) => 
        {
            Debug.Log(damage);
            target.Hit(damage); 
        };
    }
}
