using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellenAttackSummon : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;

    void Start()
    {
        // Summon enemies
        for (int i = 0; i < enemyCount; i++)
        {
            // Calculate a random position around the boss
            Vector2 spawnPosition = Random.insideUnitCircle * 100f + (Vector2)transform.position;

            // Instantiate an enemy at the calculated position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Minion spawned");
        }

        // Destroy the attack object after summoning enemies
        Destroy(gameObject);
    }
}