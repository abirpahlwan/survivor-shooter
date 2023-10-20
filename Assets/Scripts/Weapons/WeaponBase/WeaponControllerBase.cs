using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Base Weapon Controller
/// </summary>
public class WeaponControllerBase : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    public float pierce;
    
    private float currentCooldownTimer;

    [Header("Player")]
    protected PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        currentCooldownTimer = cooldownDuration; // at start current cooldown time would be max cooldown duration
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldownTimer -= Time.deltaTime;
        // when the cooldown timer becomes zero, attack
        if (currentCooldownTimer <= 0)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldownTimer = cooldownDuration;
    }
}
