using MyGame.Player;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseGun : MonoBehaviour
{
    public float bulletSpeed = 1f;
    public float attackSpeed = 1f;

    public Transform playerTransform; // Reference to the player's transform
    public float distance = 0.5f; // Distance from the player
    public GameObject projectilePrefab; // The prefab of the projectile

    private float nextFireTime = 0f; // Time of the next allowed shot

    void Start()
    {
        // Find the first GameObject with the specified tag
        GameObject foundObject = GameObject.FindWithTag("Player");

        // Check if the object was found
        if (foundObject != null)
        {
            // Assign the transform of the found object to targetTransform
            playerTransform = foundObject.transform;
            Debug.Log("Object found and assigned: " + foundObject.name);
        }
        else
        {
            Debug.Log("No object found with the specified tag.");
        }
    }
    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set z-coordinate to 0 for 2D

        // Calculate the direction from the player to the mouse
        Vector2 direction = (mousePosition - playerTransform.position).normalized;

        // Calculate the position 0.5 units away from the player in the mouse direction
        Vector2 targetPosition = new Vector2(playerTransform.position.x, playerTransform.position.y) + direction * distance;

        // Set the object's position
        transform.position = targetPosition;

        // Rotate the object to face the mouse
        transform.up = direction; // Use transform.up for 2D rotation

        // Handle projectile firing
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + 1f / attackSpeed; // Set the next fire time
        }

        
    }

    void FireProjectile()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Set the projectile's initial velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
    }
}