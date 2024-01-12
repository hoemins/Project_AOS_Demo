using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionInfo
{
    private int hp;
    private int maxHp;

    private int physicalAtk; // 공격력
    private int phsicalDef; // 방어력
    private int magicalResistance; // 마법 저항력

    private float physicalAtkDelay; // 공격 속도
    private float moveSpeed; // 이동 속도

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
