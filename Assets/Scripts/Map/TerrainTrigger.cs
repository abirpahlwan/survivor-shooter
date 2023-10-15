using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTrigger : MonoBehaviour
{
    private MapController mapController;
    private TerrainChunk targetChunk;
    
    void Start()
    {
        mapController = FindObjectOfType<MapController>();
        targetChunk = transform.parent.GetComponent<TerrainChunk>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mapController.currentChunk = targetChunk;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (mapController.currentChunk == targetChunk)
            {
                mapController.currentChunk = null;
            }
        }
    }
}
