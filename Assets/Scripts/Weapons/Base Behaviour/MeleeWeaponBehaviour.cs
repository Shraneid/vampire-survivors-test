using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : WeaponBehaviour
{
    [HideInInspector]
    public float currentDamage;
    [HideInInspector]
    public float currentCooldownDuration;

    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentCooldownDuration = weaponData.CooldownDuration;
    }

    protected override void ApplyHit(Enemy enemy)
    {
        enemy.TakeDamage(currentDamage);
    }
}
