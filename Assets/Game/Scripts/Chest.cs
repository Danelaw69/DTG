using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.Player;

public class Chest : MonoBehaviour
{
    // Define the loot pool
    public List<GameObject> lootItems;

    // The chance of dropping an item (0-100)
    public int dropChance = 100;

    // Function to generate loot when the chest is opened
    public void OpenChest()
    {
        // Check if a drop should occur
        if (Random.Range(0, 100) <= dropChance)
        {
            // Choose a random item from the loot pool
            int randomIndex = Random.Range(0, lootItems.Count);
            GameObject lootItem = lootItems[randomIndex];

            // Instantiate the loot item at the chest's position
            Instantiate(lootItem, transform.position, Quaternion.identity);
        }
    }
}