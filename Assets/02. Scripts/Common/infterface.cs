using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public interface IHitable
{
    int Hp { get; set; }
    bool IsDie { get; }
    void Hit(int value);
}


public interface IAttackable
{
    void Attack();
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

// ��ų ����Ʈ ��ũ��Ʈ�� �������־���� �������̽� ���
// ���� è�Ǿ��� ���¸� �����ų �� ����
public interface IStunable
{
    Champion TargetChampion { get; set; }
    void Stun();
}

public interface ISlowdownable
{
    Champion TargetChampion { get; set; }
    void Slowdown();
}

public interface IAirbornable
{
    Champion TargetChampion { get; set; }
    void Airborne();
}