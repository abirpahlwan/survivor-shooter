using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemDropper : MonoBehaviour
{
    public List<PickupItem> items;
    
    
}

[System.Serializable]
public class PickupItem
{
    public string       itemName;
    public GameObject   itemPrefab;
    public float        dropRate;
}
