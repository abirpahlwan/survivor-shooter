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

    // Current Stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int   currentPierce;
    
    protected Vector3 direction;
    public float destroyAfterSeconds;

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

    void Pierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Pierce();
            
            EnemyControllerBase enemy = other.GetComponent<EnemyControllerBase>();
            enemy.TakeDamage(currentDamage);
        }
    }
}
