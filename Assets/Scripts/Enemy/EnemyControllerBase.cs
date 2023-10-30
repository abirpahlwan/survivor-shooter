using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBase : MonoBehaviour
{
    [Header("Enemy Stats")]
    public EnemyScriptableObject enemyData;
    
    // Current Stats
    public float currentMoveSpeed;
    public float currentHealth;
    public float currentDamage;

    private EnemyFlash enemyFlashFX;

    private void Awake()
    {
        currentMoveSpeed = enemyData.moveSpeed;
        currentHealth = enemyData.maxHealth;
        currentDamage = enemyData.damage;
    }

    private void Start()
    {
        enemyFlashFX = GetComponent<EnemyFlash>();
    }

    public void TakeDamage(float damage)
    {
        enemyFlashFX.Flash();

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
