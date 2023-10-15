using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> TerrainChunks;
    [SerializeField] private float chunkCheckRadius;
    [SerializeField] private Vector3 newChunkPosition;
    [SerializeField] private LayerMask terrainLayerMask;
    
    [SerializeField] private Transform player;
    private PlayerMovement playerMovement;

    public TerrainChunk currentChunk;
    private GameObject newChunk;
    [SerializeField] private List<GameObject> spawnedChunks;
    float distanceFromChunk;
    [SerializeField] float maxDistanceFromChunk;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        HandleMap();
        OptimizeMap();
    }

    void HandleMap()
    {
        if(!currentChunk)
        {
            return;
        }

        if (playerMovement.moveDirection.x > 0 && playerMovement.moveDirection.y == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.Right.position, chunkCheckRadius, terrainLayerMask))
            {
                newChunkPosition = currentChunk.Right.position;
                GenerateMap();
            }
        }
        else if (playerMovement.moveDirection.x < 0 && playerMovement.moveDirection.y == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.Left.position, chunkCheckRadius, terrainLayerMask))
            {
                newChunkPosition = currentChunk.Left.position;
                GenerateMap();
            }
        }
        else if (playerMovement.moveDirection.y > 0 && playerMovement.moveDirection.x == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.Up.position, chunkCheckRadius, terrainLayerMask))
            {
                newChunkPosition = currentChunk.Up.position;
                GenerateMap();
            }
        }
        else if (playerMovement.moveDirection.y < 0 && playerMovement.moveDirection.x == 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.Down.position, chunkCheckRadius, terrainLayerMask))
            {
                newChunkPosition = currentChunk.Down.position;
                GenerateMap();
            }
        }
        else if (playerMovement.moveDirection.x > 0 && playerMovement.moveDirection.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.UpRight.position, chunkCheckRadius, terrainLayerMask))
            {
                newChunkPosition = currentChunk.UpRight.position;
                GenerateMap();
            }
        }
        else if (playerMovement.moveDirection.x > 0 && playerMovement.moveDirection.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.DownRight.position, chunkCheckRadius, terrainLayerMask))
            {
                newChunkPosition = currentChunk.DownRight.position;
                GenerateMap();
            }
        }
        else if (playerMovement.moveDirection.x < 0 && playerMovement.moveDirection.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.UpLeft.position, chunkCheckRadius, terrainLayerMask))
            {
                newChunkPosition = currentChunk.UpLeft.position;
                GenerateMap();
            }
        }
        else if (playerMovement.moveDirection.x < 0 && playerMovement.moveDirection.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentChunk.DownLeft.position, chunkCheckRadius, terrainLayerMask))
            {
                newChunkPosition = currentChunk.DownLeft.position;
                GenerateMap();
            }
        }
    }

    void GenerateMap()
    {
        int chunkIndex = Random.Range(0, TerrainChunks.Count);
        newChunk = Instantiate(TerrainChunks[chunkIndex], newChunkPosition, Quaternion.identity);
        spawnedChunks.Add(newChunk);
    }

    void OptimizeMap()
    {
        foreach (var chunk in spawnedChunks)
        {
            distanceFromChunk = Vector3.Distance(player.position, chunk.transform.position);
            if (distanceFromChunk > maxDistanceFromChunk)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
    
}
