using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Player Config
    public CharacterScriptableObject playerData;
    
    // Current Stats
    private float currentHealth;
    private float currentRecovery;
    private float currentMoveSpeed;
    private float currentMight;
    private float currentProjectileSpeed;
    
    // XP and Level-up
    [Header("XP & Level-up")]
    private int xp = 0;
    private int level = 1;
    private int xpCap;

    public List<LevelRange> levelRanges;

    void Start()
    {
        xpCap = levelRanges[0].xpCapIncrease;
    }

    void Awake()
    {
        currentHealth = playerData.MaxHealth;
        currentRecovery = playerData.Recovery;
        currentMoveSpeed = playerData.MoveSpeed;
        currentMight = playerData.Might;
        currentProjectileSpeed = playerData.ProjectileSpeed;
    }

    public void IncreaseXP(int amount)
    {
        xp += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if (xp >= xpCap)
        {
            level++;
            xp -= xpCap;

            int xpCapIncrease = 0;
            foreach (var range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    xpCapIncrease = range.xpCapIncrease;
                    break;
                }
            }
            xpCap += xpCapIncrease;
        }
    }

    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player is Dead");
    }
}

[System.Serializable]
public class LevelRange
{
    public int startLevel;
    public int endLevel;
    public int xpCapIncrease;
}
