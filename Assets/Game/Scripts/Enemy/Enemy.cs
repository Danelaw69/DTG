using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MyGame.rooms;

namespace MyGame.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public float maxHealth = 10f; // Maximum health of the enemy
        public float currentHealth; // Current health of the enemy

        private Transform target; // The target the enemy should walk towards

        private NavMeshAgent agent; // Reference to the NavMeshAgent

        public Rooms rooms;
        public Rooms room1;

        public GameObject doorclosed;
        public GameObject dooropen;


        private void Start()
        {
            doorclosed = GameObject.FindWithTag("Door closed");
            dooropen = GameObject.FindWithTag("Door open");

            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                // Store the player's transform
                target = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player not found!");
            }


            agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component
            agent.updateRotation = false; // Optional: Disable rotation updates
            agent.updateUpAxis = false; // Optional: Disable up axis updates

            currentHealth = maxHealth; // Initialize health at the start
        }

        private void Update()
        {
            // Check if the target is valid (not null)
            if (target != null)
            {
                // Set the destination for the NavMeshAgent
                agent.SetDestination(target.position);
            }
        }

        // Function to apply damage to the enemy
        public void TakeDamage(float damageAmount)
        {
            currentHealth -= damageAmount; // Reduce health by the damage amount

            // Check if the enemy is dead
            if (currentHealth <= 0f)
            {
                Die(); // Call the Die function when health reaches zero
            }
        }

        // Function to handle enemy death
        private void Die()
        {
            // Add your death logic here:
            // - Play death animation
            // - Destroy the enemy object
            // - Drop loot (optional)
            // - Trigger events (optional)

            Destroy(gameObject); // Destroy the enemy object
            rooms.RoomEnemiesAlive -= 1;
            room1.RoomEnemiesAlive -= 1;
            if (rooms.RoomEnemiesAlive <= 0)
            {
                doorclosed.transform.localScale = new Vector2(0, 0);
                dooropen.transform.localScale = new Vector2(1, 1);
            }
        }
    }
}