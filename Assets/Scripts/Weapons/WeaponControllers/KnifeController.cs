using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponControllerBase
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject knife = Instantiate(weaponData.prefab);
        knife.transform.position = transform.position;
        knife.GetComponent<KnifeBehaviour>().SetDirection(playerMovement.lastMoveDirection);
    }
}
