using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponControllerBase
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void  Attack()
    {
        base.Attack();
        GameObject garlic = Instantiate(prefab);
        garlic.transform.position = transform.position;
        garlic.transform.parent = transform;
    }
}
