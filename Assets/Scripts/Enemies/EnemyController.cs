using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform playerTransform;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            playerTransform.position, 
            enemyData.MoveSpeed * Time.deltaTime
        );
    }
}
