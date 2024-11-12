using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyGame.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public float maxHealth = 10f; // Maximum health of the enemy
        public float currentHealth; // Current health of the enemy

        public Transform target;

        NavMeshAgent agent;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            currentHealth = maxHealth; // Initialize health at the start
        }

        private void Update()
        {
            agent.SetDestination(target.position);
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
        }
    }
}