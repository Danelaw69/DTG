using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellenAttackBurst : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int projectileCount;
    public float projectileSpeed;
    public float burstRadius;

    void Update()
    {


        // Launch projectiles in a burst
        for (int i = 0; i < projectileCount; i++)
        {
            // Calculate a random position within the burst radius *around* the boss
            Vector2 spawnPosition = Random.insideUnitCircle * burstRadius + (Vector2)transform.position;

            // Instantiate a projectile at the calculated spawn position
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

            // Calculate direction towards the player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector2 playerPosition = player.transform.position;
                Vector2 direction = (playerPosition - spawnPosition).normalized;

                // Set the projectile's initial velocity
                projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            }
            else
            {
                Debug.LogError("Player not found!");
            }

            //if (travelDistance >= range)
            //{
            //Destroy(gameObject);
            //}
        }

        // Destroy the attack object after launching projectiles
        Destroy(gameObject);
    }
}