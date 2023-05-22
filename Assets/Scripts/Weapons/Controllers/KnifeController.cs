using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class KnifeController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        GameObject knife = Instantiate(weaponData.Prefab);

        knife.transform.position = transform.position;
        knife.transform.parent = transform;

        float angle = Mathf.Atan2(playerController.weaponMovementDirection.y, playerController.weaponMovementDirection.x) * Mathf.Rad2Deg;
        knife.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        knife.GetComponent<KnifeBehaviour>().SetMovementDirection(playerController.weaponMovementDirection);
    }
}
