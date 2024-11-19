using MyGame.playerHealth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHealth playerHealth;
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.MaxHealth;
        healthBar.value = playerHealth.MaxHealth;
    }
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}