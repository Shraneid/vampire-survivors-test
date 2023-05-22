using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Custom/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; set { prefab = value; } }

    [SerializeField]
    float lifetimeBeforeDestroy;
    public float LifetimeBeforeDestroy { get => lifetimeBeforeDestroy; set => lifetimeBeforeDestroy = value; }

    [SerializeField]
    float damage;
    public float Damage { get => damage; set => damage = value; }

    [SerializeField]
    float speed;
    public float Speed { get => speed; set => speed = value; }

    [SerializeField]
    float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; set => cooldownDuration = value; }

    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; set => pierce = value; }
}
