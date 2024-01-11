using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : Building
{
    private new void Start()
    {
        base.Start();
        // 건물이름, 체력, 방어력, 마법저항력
        buildingInfo = new BuildingInfo("Nexus", 3000, 30, 30);

        OnDestroy += () => { Debug.Log("Nexus Destroy"); };
    }
}
