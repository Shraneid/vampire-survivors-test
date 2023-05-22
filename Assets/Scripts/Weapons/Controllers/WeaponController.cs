using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    [Header("Weapon Base Stats")]
    public WeaponScriptableObject weaponData;

    float currentCooldown;

    protected PlayerController playerController;
    
    protected virtual void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        currentCooldown = weaponData.CooldownDuration;
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0 )
        {
            Attack();
            currentCooldown = weaponData.CooldownDuration;
        }
    }

    protected abstract void Attack();
}
