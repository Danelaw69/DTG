using UnityEngine;

public class EnemyGunBase : MonoBehaviour
{
    public float EbulletSpeed = 1f;
    public float EattackSpeed = 1f;

    public Transform playerTransform; // Reference to the player's transform
    public GameObject projectilePrefab; // The prefab of the projectile

    private float nextFireTime = 0f; // Time of the next allowed shot

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // Store the player's transform
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }
    void Update()
    {
        // Only fire if the player is within a certain range
        if (Vector2.Distance(transform.position, playerTransform.position) < 100f)
        {
            // Handle projectile firing
            if (Time.time >= nextFireTime)
            {
                FireProjectile();
                nextFireTime = Time.time + 1f / EattackSpeed; // Set the next fire time
            }
        }

        // Rotate the gun to face the player
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.up = direction;
    }

    void FireProjectile()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Set the projectile's initial velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * EbulletSpeed;
        }
    }
}