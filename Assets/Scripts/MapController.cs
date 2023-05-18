using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject chunkToRender;
    public GameObject player;

    public const int CHUNK_SIZE = 32;
    public const int NUMBER_OF_CHUNKS_LOADED = 2;
    
    Dictionary<Vector2, GameObject> terrainChunksDict;

    void Start()
    {
        terrainChunksDict = new();

        InvokeRepeating("UpdateMap", 0, 1.0f);
    }

    void UpdateMap()
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
        for (int i = (int)Mathf.Ceil(currentPlayerChunkPos.x) - NUMBER_OF_CHUNKS_LOADED; i <= (int)Mathf.Ceil(currentPlayerChunkPos.x) + NUMBER_OF_CHUNKS_LOADED; i++)
        {
            for (int j = (int)Mathf.Ceil(currentPlayerChunkPos.y) - NUMBER_OF_CHUNKS_LOADED; j <= (int)Mathf.Ceil(currentPlayerChunkPos.y + NUMBER_OF_CHUNKS_LOADED); j++)
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
        List<Vector2> chunkPositionsToRemove = terrainChunksDict.Keys.Where(
            chunkPosition => Vector2.Distance(currentPlayerChunkPos, chunkPosition) > Mathf.Pow(NUMBER_OF_CHUNKS_LOADED, 2)
        ).ToList();

        if (!chunkPositionsToRemove.Any()) return;
        
        foreach (var chunkPos in chunkPositionsToRemove)
        {
            terrainChunksDict[chunkPos].SetActive(false);
        }
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
    }
}
