using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.playerHealth;
using MyGame.HHealthBar;

public class MaxHealth : MonoBehaviour
{
    private PlayerHealth playerhealth;
    private HealthBar healthBar;

    void Start()
    {
        playerhealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        healthBar = GameObject.Find("Health Bar(Player)").GetComponent<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            playerhealth.MaxHealth += 1;
            playerhealth.CurrentHealth += 1;
            healthBar.UpdateHealthBar();
            Debug.Log("MaxhealthUp " + playerhealth.MaxHealth);
            Destroy(gameObject);

        }
    }
}