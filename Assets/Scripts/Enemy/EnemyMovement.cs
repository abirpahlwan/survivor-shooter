using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyControllerBase enemyController;
    private Transform player;
    
    void Start()
    {
        enemyController = GetComponent<EnemyControllerBase>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyController.currentMoveSpeed * Time.deltaTime);
        }
    }
}
