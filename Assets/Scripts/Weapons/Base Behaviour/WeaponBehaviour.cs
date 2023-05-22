using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    List<Enemy> listOfEnemiesHitBeforeCooldown;

    protected virtual void Start()
    {
        listOfEnemiesHitBeforeCooldown = new List<Enemy>();
        Destroy(gameObject, weaponData.LifetimeBeforeDestroy);
    }

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();

            if (!listOfEnemiesHitBeforeCooldown.Contains(enemy))
            {
                listOfEnemiesHitBeforeCooldown.Add(enemy);
                ApplyHit(enemy);
            }
        }
    }

    protected abstract void ApplyHit(Enemy enemy);
}
