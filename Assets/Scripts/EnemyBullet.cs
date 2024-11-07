using UnityEngine;
using MyGame.Player;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f; // Bullet speed
    public float damage = 5f; // Damage the bullet inflicts
    public float range = 5f; // Bullet's travel distance

    private float travelDistance = 0f; // Distance traveled

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Increase travel distance
        travelDistance += speed * Time.deltaTime;

        // Destroy the bullet if it exceeds its range
        if (travelDistance >= range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet hits the player or a wall
        if (collision.CompareTag("Player") || collision.CompareTag("Wall"))
        {
            // Apply damage to the player (if it's the player)
            if (collision.CompareTag("Player"))
            {
                // Assuming your Player script is in the same namespace as Bullet
                PlayerController playerController = collision.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.TakeDamage(damage);
                }
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
