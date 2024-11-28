using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.playerHealth;

public class Healing : MonoBehaviour
{
    private PlayerHealth playerhealth;



    void Start()
    {
        playerhealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        int currentHealth = playerhealth.CurrentHealth;
        int maxHealth = playerhealth.MaxHealth;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playerhealth.CurrentHealth < playerhealth.MaxHealth)
        {
            playerhealth.CurrentHealth += 1;

            if (playerhealth.CurrentHealth > playerhealth.MaxHealth)
            {
                playerhealth.CurrentHealth = playerhealth.MaxHealth;
            }
            Debug.Log("health");
        }
    }
}