using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    // Intergars
    public int RoomNumber;
    public int RoomEnemyCount;

    // Bools
    public bool RoomDone = false;
    public bool CombatActive = false;

    // Attach References
    public GameObject enemyPrefab; // Prefab for enemies
    public GameObject doorclosed;
    public GameObject dooropen;
    public GameObject EnemySpawn1;
    public GameObject EnemySpawn2;


    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn1 = GameObject.Find("Enemy Spawn 1");
        EnemySpawn1 = GameObject.Find("Enemy Spawn 2");
        doorclosed = GameObject.FindWithTag("Door closed");
        dooropen = GameObject.FindWithTag("Door open");
        doorclosed.transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame

    void Update()
    {
        /*
        if (CombatActive == false)
        {
            GameObject.Find("Doors").transform.localScale = new Vector2(0, 0);
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (RoomDone == false)
        {
            if (collision.CompareTag("Player"))
            {
                if (RoomNumber == 1)
                {
                    doorclosed.transform.localScale = new Vector2(1, 1);
                    dooropen.transform.localScale = new Vector2(0, 0);
                    CombatActive = true;
                    // Summon enemies
                    for (int i = 0; i < RoomEnemyCount; i++)
                    {
                        // Calculate a random position around the boss
                        // Vector2 spawnPosition = EnemySpawn1 && EnemySpawn2;

                        // Instantiate an enemy at the calculated position
                        // Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    }

                }
                if (RoomNumber == 2)
                {
                    
                }
                if (RoomNumber == 3)
                {

                }
                Debug.Log("Room event Triggered");
            }
        }        
    }
}
