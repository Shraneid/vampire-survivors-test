using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }
    
    protected override void Attack()
    {
        GameObject garlic = Instantiate(weaponData.Prefab);

        garlic.transform.position = transform.position;
        garlic.transform.parent = transform;
    }
}
