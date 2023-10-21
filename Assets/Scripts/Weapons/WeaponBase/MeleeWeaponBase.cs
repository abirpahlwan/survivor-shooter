using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for projectile weapons
/// </summary>
public class MeleeWeaponBase : MonoBehaviour
{
    public float destroyAfterSeconds;
    
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
}
