using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "B0ts/Weapons/Laser Gun", fileName = "Laser Gun")]
public class LaserGunStats : WeaponStats
{
    public float damage;
    public float range;
    public float cooldown;


    public float beamWidth;
    public float beamDuration;
}
