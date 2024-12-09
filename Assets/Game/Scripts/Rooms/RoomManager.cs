using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.rooms;

public class RoomManager : MonoBehaviour
{
    public Rooms rooms; // Reference to your Rooms manager
    public GameObject[] Rooms; // Array of room GameObjects
    private int currentActiveRoom = -1; // Track the currently active room
    private bool[] roomActivated; // Track if rooms have been activated

    // Start is called before the first frame update
    void Start()
    {
        roomActivated = new bool[Rooms.Length]; // Initialize the activation tracker
        for (int i = 0; i < Rooms.Length; i++)
        {
            roomActivated[i] = false; // Set all rooms to inactive initially
            Rooms[i].SetActive(false); // Deactivate all rooms
        }
    }

    // Update is called once per frame
    void Update()
    {
        // No need for key input to activate rooms anymore
        for (int i = 0; i < Rooms.Length; i++)
        {
            Rooms[i].SetActive(i == currentActiveRoom);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Check if the room has not been activated yet
            for (int i = 0; i < Rooms.Length; i++)
            {
                if (Rooms[i].GetComponent<Collider2D>().IsTouching(collision) && !roomActivated[i])
                {
                    currentActiveRoom = i; // Set the current active room
                    roomActivated[i] = true; // Mark this room as activated
                    Rooms[i].SetActive(true); // Activate the room
                    break; // Exit the loop after activating the room
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the collider is an enemy
        if (other.CompareTag("Enemy"))
        {
            // If there's an enemy in the room, do nothing (room stays active)
            return;
        }

        // If no enemies are found, deactivate the room
        for (int i = 0; i < Rooms.Length; i++)
        {
            if (Rooms[i].GetComponent<Collider2D>().IsTouching(other) && roomActivated[i])
            {
                roomActivated[i] = false; // Mark the room as inactive
                Rooms[i].SetActive(false); // Deactivate the room
                break; // Exit the loop after deactivating the room
            }
        }
    }
}