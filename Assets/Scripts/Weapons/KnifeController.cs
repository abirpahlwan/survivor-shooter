using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void  Attack()
    {
        base.Attack();
        GameObject knife = Instantiate(prefab);
        knife.transform.position = transform.position;
        knife.GetComponent<KnifeBehaviour>().DirectionChecker(playerMovement.moveDirection);
    }
}
