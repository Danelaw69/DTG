using UnityEngine;

public class GunDispenser : MonoBehaviour
{
    public GameObject gunPrefab; // Assign your gun prefab in the inspector
    private bool playerInRange;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUpGun();
        }
    }

    private void PickUpGun()
    {
        // Instantiate the gun and parent it to the player
        GameObject gun = Instantiate(gunPrefab, transform.position, Quaternion.identity);
        // Assuming you have a reference to the player
        gun.transform.SetParent(GameObject.FindWithTag("Player").transform);
        // Optionally, you can disable the dispenser or destroy it
        Destroy(gameObject); // or set it inactive
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}