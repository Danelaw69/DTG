using UnityEngine;

namespace MyGame.bulletHellen
{
    public class BulletHellen : MonoBehaviour
    {
        // Boss Stats
        public float BossCurrentHealth = 0;       
        public float BossMaxHealth = 50;
        public float attackCooldown;

        // Attack References
        public GameObject shotPrefab; // Prefab for individual shots
        public GameObject enemyPrefab; // Prefab for enemies
        public GameObject burstProjectilePrefab; // Prefab for burst projectiles

        // Attack Bag
        public GameObject[] attacks; // Make attacks public

        // Internal Variables
        private float cooldownTimer;
        public float attackRange = 5f; // Add a public variable for attack range

        // Bools
        public bool BossAlive = true;

        // Thing
        public BossHealthBar bossHealthBar;

        void Start()
        {
            // Initialize attack bag
            // **No need to create attacks here anymore**
            BossCurrentHealth = BossMaxHealth;
            cooldownTimer = attackCooldown;
        }

        // Attack Functions
        private GameObject CreateRandomShotAttack()
        {
            // Create a new GameObject to represent the attack
            GameObject attack = new GameObject("RandomShotAttack");
            attack.transform.parent = transform; // Parent it to the boss

            // Add a component to handle the attack logic
            HellenAttackSpin logic = attack.AddComponent<HellenAttackSpin>();
            logic.shotPrefab = shotPrefab;
            logic.shotCount = 2; // Adjust the number of shots
            logic.shotSpeed = 5f; // Adjust the shot speed
            logic.shotSpread = 45f; // Adjust the spread angle

            return attack;
        }

        private GameObject CreateEnemySummonAttack()
        {
            // Create a new GameObject to represent the attack
            GameObject attack = new GameObject("EnemySummonAttack");
            attack.transform.parent = transform;

            // Add a component to handle the attack logic
            HellenAttackSummon logic = attack.AddComponent<HellenAttackSummon>();
            logic.enemyPrefab = enemyPrefab;
            logic.enemyCount = 5; // Adjust the number of enemies

            return attack;
        }

        private GameObject CreateBurstAttack()
        {
            // Create a new GameObject to represent the attack
            GameObject attack = new GameObject("BurstAttack");
            attack.transform.parent = transform;

            // Add a component to handle the attack logic
            HellenAttackBurst logic = attack.AddComponent<HellenAttackBurst>();
            logic.projectilePrefab = burstProjectilePrefab;
            logic.projectileCount = 5; // Adjust the number of projectiles
            logic.projectileSpeed = 10f; // Adjust the projectile speed
            logic.burstRadius = 2f; // Adjust the burst radius

            return attack;
        }

        // Update is called once per frame
        void Update()
        {
            cooldownTimer -= Time.deltaTime;

            // Get the player's position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // Check if the player is within the attack range
                if (Vector2.Distance(transform.position, player.transform.position) <= attackRange)
                {
                    //Debug.Log("in Range");
                    if (cooldownTimer <= 0)
                    {
                        int randomIndex = Random.Range(0, attacks.Length);
                        // **Instantiate the attack object here**
                        GameObject chosenAttack = Instantiate(attacks[randomIndex]);

                        chosenAttack.transform.position = transform.position;

                        cooldownTimer = attackCooldown;
                    }
                }
            }
        }

        public void TakeDamage(float damage)
        {
            BossCurrentHealth -= damage;
            bossHealthBar.SetBossHealth(BossCurrentHealth);
            if (BossCurrentHealth <= 0)
            {
                Time.timeScale = 0;
                GameObject.Find("Win Screen").transform.localScale = new Vector2(1, 1);
                GameObject.Find("Menu Background").transform.localScale = new Vector2(1, 1);
                BossAlive = false;
                Destroy(gameObject);
            }
        }
    }
}





// Attack Logic Scripts (Add these as separate scripts)

// Random Shot Attack

// Enemy Summon Attack


// Burst Attack
