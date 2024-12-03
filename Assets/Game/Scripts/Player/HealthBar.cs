using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyGame.playerHealth;

namespace MyGame.HHealthBar
{
    public class HealthBar : MonoBehaviour
    {
        public Slider healthBar;
        public PlayerHealth playerHealth;
        private void Start()
        {
            UpdateHealthBar();
        }
        public void SetHealth(int hp)
        {
            healthBar.value = hp;
        }
        // Updates the maximum value for the healthbar
        public void UpdateHealthBar()
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            healthBar = GetComponent<Slider>();
            healthBar.maxValue = playerHealth.MaxHealth;
            healthBar.value = playerHealth.MaxHealth;
        }
    }
}