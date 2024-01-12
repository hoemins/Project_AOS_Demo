using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionInfo
{
    private int hp;
    private int maxHp;

    private int physicalAtk; // ���ݷ�
    private int phsicalDef; // ����
    private int magicalResistance; // ���� ���׷�

    private float physicalAtkDelay; // ���� �ӵ�
    private float moveSpeed; // �̵� �ӵ�

    public MinionInfo(int hp, int physicalAtk,int phsicalDef, int magicalRsistance, float physicalAtkDelay, float moveSpeed)
    {
        this.maxHp = hp;
        this.hp = hp;
        this.physicalAtk = physicalAtk;
        this.phsicalDef = phsicalDef;
        this.magicalResistance = magicalRsistance;
        this.physicalAtkDelay = physicalAtkDelay;
        this.moveSpeed = moveSpeed;
    }
}

public class Minion : MonoBehaviour
{
    protected MinionInfo minionInfo;

    MinionBT minionBT;

    private void Start()
    {
        minionBT = GetComponent<MinionBT>();
    }
}
