using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Poolable
{
    public EnemyScriptableObject enemyData;

    public float CurrentMoveSpeed { get; private set; }
    public float CurrentHealth { get; private set; }
    public float CurrentDamage { get; private set; }

    private void OnEnable()
    {
        CurrentMoveSpeed = enemyData.MoveSpeed;
        CurrentHealth = enemyData.MaxHealth;
        CurrentDamage = enemyData.Damage;
    }

    public void TakeDamage(float dmg) {
        CurrentHealth -= dmg;

        if (CurrentHealth <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        ReleaseObject();
    }
}
