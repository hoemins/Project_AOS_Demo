using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : Building
{
    private new void Start()
    {
        base.Start();
        // �ǹ��̸�, ü��, ����, �������׷�
        buildingInfo = new BuildingInfo("Nexus", 3000, 30, 30);

        OnDestroy += () => { Debug.Log("Nexus Destroy"); };
    }
}
