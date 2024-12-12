using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.HHealthBar;
using MyGame.Player;
namespace MyGame.playerHealth
{
    public class PlayerHealth : MonoBehaviour
    {
        public int CurrentHealth = 0;
        public int MaxHealth = 6;
        //private Player player;
        private HealthBar healthBar;
        public bool playerAlive = true;
        void Start()
        {
            //player = GameObject.Find("Player").GetComponent<PlayerController>();
            healthBar = GameObject.Find("Health Bar(Player)").GetComponent<HealthBar>();
            CurrentHealth = MaxHealth;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                DamagePlayer(1);
            }
            if (CurrentHealth <= 0)
            {
                Time.timeScale = 0;
                GameObject.Find("End Screen Buttons").transform.localScale = new Vector2(1, 1);
                GameObject.Find("Menu Background").transform.localScale = new Vector2(1, 1);
                playerAlive = false;
            }
            if (CurrentHealth > 0)
            {
                healthBar.SetHealth(CurrentHealth);
                
            }
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }

        }
        public void DamagePlayer(int damage)
        {
            CurrentHealth -= damage;
            healthBar.SetHealth(CurrentHealth);
            //if (Player.isDashing == false)
            //{
            //    CurrentHealth -= damage;
            //    healthBar.SetHealth(CurrentHealth);
            //}
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                DamagePlayer(1);
            }
        }
    }
}
