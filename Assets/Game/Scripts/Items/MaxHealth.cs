using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.playerHealth;

public class MaxHealth : MonoBehaviour
{
    private PlayerHealth playerhealth;

    void Start()
    {
        playerhealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            playerhealth.MaxHealth += 1;

            

            Debug.Log("MaxhealthUp " + playerhealth.MaxHealth);

            Destroy(gameObject);

        }
    }
}