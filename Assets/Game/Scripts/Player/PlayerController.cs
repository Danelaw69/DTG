using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Chest chest;

        public GameObject[] weapons;
        private int currentWeaponIndex = 0;

        public float movmentSpeed = 4f;
        public float dashRange = 0.4f;
        public float dashSpeed = 8.0f;
        public float dashCooldown = 1.0f;

        private float activeMoveSpeed;
        private float dashCounter;
        private float dashCoolCounter;

        private Rigidbody2D rb;

        private Vector2 movementDirection;

        

        // Start is called before the first frame update
        void Start()
        {
            activeMoveSpeed = movmentSpeed;
            rb = GetComponent<Rigidbody2D>();
            
            
        }

        // Update is called once per frame
        void Update()
        {
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (dashCoolCounter <= 0 && dashCounter <= 0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashRange;
                }
            }

            if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;

                if (dashCounter <= 0)
                {
                    activeMoveSpeed = movmentSpeed;
                    dashCoolCounter = dashCooldown;
                }
            }


            // Check for key presses (1-5)
            if (Input.GetKeyDown(KeyCode.Alpha1)) { currentWeaponIndex = 0; }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { currentWeaponIndex = 1; }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { currentWeaponIndex = 2; }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { currentWeaponIndex = 3; }
            if (Input.GetKeyDown(KeyCode.Alpha5)) { currentWeaponIndex = 4; }

            // Ensure the index stays within the bounds of the weapons array
            currentWeaponIndex = Mathf.Clamp(currentWeaponIndex, 0, weapons.Length - 1);

            // Activate the selected weapon and deactivate the others
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(i == currentWeaponIndex);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Chest"))
            {
                chest = other.GetComponent<Chest>();
                chest.OpenChest();
            }
        }

        void FixedUpdate()
        {
            rb.velocity = movementDirection * activeMoveSpeed;
        }
    }
}
