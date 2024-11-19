using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.playerHealth
{
    public class PlayerHealth : MonoBehaviour
    {
        public int CurrentHealth = 0;
        public int MaxHealth = 6;
        public HealthBar healthBar;
        public bool playerAlive = true;
        void Start()
        {
            CurrentHealth = MaxHealth;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                DamagePlayer(1);
            }
            if (CurrentHealth < 1)
            {
                playerAlive = false;
            }
        }
        public void DamagePlayer(int damage)
        {
            CurrentHealth -= damage;
            healthBar.SetHealth(CurrentHealth);
        }
    }
}
