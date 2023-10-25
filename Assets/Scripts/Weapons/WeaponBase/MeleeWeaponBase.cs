using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for projectile weapons
/// </summary>
public class MeleeWeaponBase : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    
    // Current Stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int   currentPierce;
    
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
    
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyControllerBase enemy = other.GetComponent<EnemyControllerBase>();
            enemy.TakeDamage(currentDamage);
        }
    }
}
