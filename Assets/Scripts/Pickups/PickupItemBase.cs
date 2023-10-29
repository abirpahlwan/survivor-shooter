using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemBase : MonoBehaviour, IPickupItem
{
    [SerializeField] private int xpCount;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseXP(xpCount);
        Destroy(gameObject);
    }
}
