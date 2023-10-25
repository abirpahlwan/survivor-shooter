using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public GameObject prefab;
    
    // Base Stats
    public float damage;
    public float speed;
    public float cooldownDuration;
    public int   pierce;
}
