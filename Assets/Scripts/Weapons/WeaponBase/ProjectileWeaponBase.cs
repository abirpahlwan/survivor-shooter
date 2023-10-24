using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for all projectile weapons
/// </summary>
public class ProjectileWeaponBase : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    
    protected Vector3 direction;
    public float destroyAfterSeconds;
    
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.z = Utils.GetAngleFromDirection(direction);
        transform.rotation = Quaternion.Euler(rotation); 
    }
}
