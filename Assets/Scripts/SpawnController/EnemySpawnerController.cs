using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject player;

    public float spawnDistance;
    public int numberOfEnemiesToSpawn;

    private GameObjectPool enemyPool;
    private GameObject container;

    private void Awake()
    {
        enemyPool = GetComponent<GameObjectPool>();
    }

    void Start()
    {
        container = new($"{enemyPool.poolablePrefab.name}_Pool");
        container.transform.SetParent( transform );

        InvokeRepeating("SpawnMissingEnemies", 0, 2f);
    }

    void SpawnMissingEnemies()
    {
        Debug.Log(enemyPool.CurrentNumberOfObjectsInUse);
        for (int i = 0; i < numberOfEnemiesToSpawn - enemyPool.CurrentNumberOfObjectsInUse ; i++)
        {
            Spawn();
        }
    }

    GameObject Spawn ()
    {
        GameObject obj = enemyPool.Pool.Get();

        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        Vector3 spawnPositionRelativeToPlayer = player.transform.position + randomRotation * Vector3.up * (spawnDistance * Random.Range(1, 1.4f));

        obj.transform.position = spawnPositionRelativeToPlayer;
        obj.transform.SetParent(container.transform);

        return obj;
    }
}