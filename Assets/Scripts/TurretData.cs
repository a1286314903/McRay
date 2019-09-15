using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretData
{
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretUpPrefab;
    public int costUp;
    public TurretType turretType;

    public enum TurretType
    {
        LaserTurret,
        MissileTurret,
        StandardTurret
    }

}
