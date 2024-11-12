using UnityEngine;
using MyGame.Enemy;

public class Bullet : MonoBehaviour
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
        // Check if the bullet hits an enemy
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
        {
            // Apply damage to the enemy
            // Assuming your Enemy script is in the same namespace as Bullet
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}