using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public interface IHitable
{
    void Hit(int value);
}

public interface IAttackable
{
    void PhysicalAttack();
}

public interface ISkillAttackable
{
    void SkillAttack();
}

public interface IDetectable
{
    void Detect();
    float DetectRange { get; }
    Collider[] Colliders { get; }
    bool IsDetected { get; }
}
