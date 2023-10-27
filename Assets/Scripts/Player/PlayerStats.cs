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
    [SerializeField] private int xp = 0;
    [SerializeField] private int level = 0;
    [SerializeField] private int xpCap = 100;
    [SerializeField] private int xpCapIncrease;

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
    }

    private void CheckLevelUp()
    {
        if (xp >= xpCap)
        {
            level++;
            xp -= xpCap;
            xpCap += xpCapIncrease;
        }
    }
}
