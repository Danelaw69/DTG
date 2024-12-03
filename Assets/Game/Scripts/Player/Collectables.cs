using MyGame.playerHealth;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    public bool coin = false;
    public bool key = false;

    public int currentMoney = 0;
    public int currentKeys = 0;
    void Start()
    {
        currentKeys = 0;
        currentMoney = 0;

        coin = GetComponent<Text>();
        key = GetComponent<Text>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            currentMoney += 1;
            Destroy(collision);
        }
        if (collision.CompareTag("Key"))
        {
            currentKeys += 1;
            Destroy(collision);
        }

    }
        
}