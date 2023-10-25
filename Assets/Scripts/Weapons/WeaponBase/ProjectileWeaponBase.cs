using System;
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
    
    // Current Stats
    public float currentDamage;
    public float currentSpeed;
    public float currentCooldownDuration;
    public int   currentPierce;

    private void Awake()
    {
        currentDamage = weaponData.damage;;
        currentSpeed = weaponData.speed;;
        currentCooldownDuration = weaponData.cooldownDuration;;
        currentPierce = weaponData.pierce;
    }

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

    protected void OnTriggerEnter2D(Collider2D other)
    {
        print($"OnTriggerEnter2D {other.name}");
        if (other.CompareTag("Enemy"))
        {
            print("Enemy Hit");
            EnemyControllerBase enemy = other.GetComponent<EnemyControllerBase>();
            enemy.TakeDamage(currentDamage);
        }
    }
}
