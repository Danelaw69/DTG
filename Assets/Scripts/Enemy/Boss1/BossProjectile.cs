using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
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
}
