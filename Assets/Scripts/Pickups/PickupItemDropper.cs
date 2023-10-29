using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemDropper : MonoBehaviour
{
    public List<PickupItem> items;

    private bool isQuitting;
    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (isQuitting) return;

        float percentage = UnityEngine.Random.Range(0f, 1f);
        // int current_weight = 0;
        foreach (var item in items)
        {
            // current_weight += item.dropRate;
            // if (percentage <= current_weight)
            if (percentage <= item.dropRate)
            {
                Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
                break;
            }
        }
    }
}

[System.Serializable]
public class PickupItem
{
    public string     itemName;
    public GameObject itemPrefab;
    public float      dropRate;
}
