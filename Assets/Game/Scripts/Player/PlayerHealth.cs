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
        }
        public void DamagePlayer(int damage)
        {
            CurrentHealth -= damage;
            healthBar.SetHealth(CurrentHealth);
        }
    }
}