using UnityEngine;

public class GunDispenser : MonoBehaviour
{
    public GameObject gunPrefab; // Assign your gun prefab in the inspector
    private bool playerInRange;

    public bool gunInHand = false;
    /*
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUpGun();
            gunInHand = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            DropGun();
            gunInHand = false;
        }
    }
    */
    public void PickUpGun()
    {
        if (gunInHand == false)
        {
            // Instantiate the gun and parent it to the player
            GameObject gun = Instantiate(gunPrefab, transform.position, Quaternion.identity);
            // Assuming you have a reference to the player
            gun.transform.SetParent(GameObject.FindWithTag("Player").transform);
            // Optionally, you can disable the dispenser or destroy it
            Destroy(gameObject); // or set it inactive
            gunInHand = true;
        }
        
    }

    public void DropGun()
    {
        if (gunInHand == true)
        {
            // Instantiate a new gun object from the prefab
            GameObject droppedGun = Instantiate(gunPrefab, transform.position, Quaternion.identity);

            // Set the dropped gun's properties to match the gun in hand
            droppedGun.transform.rotation = gunPrefab.transform.rotation;
            droppedGun.GetComponent<Rigidbody2D>().velocity = gunPrefab.GetComponent<Rigidbody2D>().velocity;

            // Set the parent of the dropped gun to null
            droppedGun.transform.SetParent(null);

            // Destroy the gun in hand
            Destroy(gunPrefab);

            // Reset the gunInHand variable
            gunInHand = false;
        }

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