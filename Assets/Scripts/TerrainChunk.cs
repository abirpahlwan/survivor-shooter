using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainChunk : MonoBehaviour
{
    [SerializeField] private List<GameObject> PropSpawnPoints;
    [SerializeField] private List<GameObject> PropPrefabs;
    
    public Transform Right;
    public Transform UpRight;
    public Transform Up;
    public Transform UpLeft;
    public Transform Left;
    public Transform DownLeft;
    public Transform Down;
    public Transform DownRight;
    
    void Start()
    {
        SpawnProps();
    }

    void Update()
    {
        
    }

    private void OnDisable()
    {
        // Destroy(gameObject);
    }

    void SpawnProps()
    {
        foreach (GameObject spawnPoint in PropSpawnPoints) {
            int propIndex = Random.Range(0, PropPrefabs.Count);
            Instantiate(PropPrefabs[propIndex], spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform);
        }
    }
}
