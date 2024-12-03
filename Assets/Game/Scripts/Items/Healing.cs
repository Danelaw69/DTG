using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.playerHealth;

public class Healing : MonoBehaviour
{
    private PlayerHealth playerhealth;

    void Start() // Corrected method name
    {
        playerhealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playerhealth.CurrentHealth < playerhealth.MaxHealth) // Changed <= to <
        {
            playerhealth.CurrentHealth += 1;

            // Ensure CurrentHealth does not exceed MaxHealth
            

            Debug.Log("Player healed. Current Health: " + playerhealth.CurrentHealth); // More descriptive log

            Destroy(gameObject);
        }
    }
}