using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base script for projectile weapons
public class MeleeWeaponBehaviourBase : MonoBehaviour
{
    public float destroyAfterSeconds;
    
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    
}
