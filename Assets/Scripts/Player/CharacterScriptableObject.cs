using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rick", menuName = "ScriptableObjects/Rick")]
public class CharacterScriptableObject : ScriptableObject
{
    public string     CharacterName;
    public GameObject StartingWeapon;
    public float      MaxHealth;
    public float      Recovery;
    public float      MoveSpeed;
    public float      Might;
    public float      ProjectileSpeed;
}
