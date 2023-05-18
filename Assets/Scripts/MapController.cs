using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MapController : MonoBehaviour
{
    const int CHUNK_SIZE = 32;

    public GameObject chunkToRender;
    public GameObject player;
    
    Dictionary<Vector2, GameObject> terrainChunksDict;
    List<Vector2> visibleChunksPositions;

    void Start()
    {
        terrainChunksDict = new();
        visibleChunksPositions = new();

        SpawnOrShowVisibleChunks(player.transform.position);
    }

    void Update()
    {
        Vector2 currentPlayerChunkPos = new(
            Mathf.Round(player.transform.position.x / 32),
            Mathf.Round(player.transform.position.y / 32)
        );
        
        SpawnOrShowVisibleChunks(currentPlayerChunkPos);
        HideFarChunks(currentPlayerChunkPos);
    }

    void SpawnOrShowVisibleChunks(Vector2 currentPlayerChunkPos)
    {
        for (int i = (int)Mathf.Ceil(currentPlayerChunkPos.x) - 1; i <= (int)Mathf.Ceil(currentPlayerChunkPos.x) + 1; i++)
        {
            for (int j = (int)Mathf.Ceil(currentPlayerChunkPos.y) - 1; j <= (int)Mathf.Ceil(currentPlayerChunkPos.y + 1); j++)
            {
                Vector2 chunkPos = new(i, j);
                if (!terrainChunksDict.ContainsKey(chunkPos))
                {
                    SpawnNewChunk(chunkPos);
                }
                else if (!terrainChunksDict[chunkPos].activeSelf)
                {
                    terrainChunksDict[chunkPos].SetActive(true);
                }
            }
        }
    }

    private void HideFarChunks(Vector2 currentPlayerChunkPos)
    {
        List<Vector2> chunkPositionsToRemove = visibleChunksPositions.Where(chunkPosition =>
               chunkPosition.x > currentPlayerChunkPos.x + 1
            || chunkPosition.x < currentPlayerChunkPos.x - 1
            || chunkPosition.y < currentPlayerChunkPos.y - 1
            || chunkPosition.y < currentPlayerChunkPos.y - 1
        ).ToList();

        if (!chunkPositionsToRemove.Any()) return;
        
        foreach (var chunkPos in chunkPositionsToRemove)
        {
            terrainChunksDict[chunkPos].SetActive(false);
        }

        visibleChunksPositions = terrainChunksDict.Values.ToList();
    }

    private void SpawnNewChunk(Vector2 chunkPos)
    {
        GameObject chunkGameObject = Instantiate(
            chunkToRender, 
            chunkPos*CHUNK_SIZE - (new Vector2(CHUNK_SIZE, CHUNK_SIZE)/2), // centering the chunk
            Quaternion.identity
        );
        chunkGameObject.transform.parent = transform;
        chunkGameObject.SetActive(true);

        terrainChunksDict.Add(chunkPos, chunkGameObject);
        visibleChunksPositions.Add(chunkPos);
    }
}
