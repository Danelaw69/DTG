using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBoss : MonoBehaviour
{
    // Intergars
    public int RoomEnemyCount;
    // Bools
    public bool CombatActive = false;
    public bool RoomDone = false;
    // Attach References
    public GameObject roomEnemyPrefab; // Prefab for enemies
    public GameObject doorclosed;
    public GameObject dooropen;
    public GameObject[] SpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        doorclosed = GameObject.FindWithTag("Door closed");
        dooropen = GameObject.FindWithTag("Door open");
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatActive == true)
        {
            if (GameObject.FindWithTag("Enemy") == null)
            {
                doorclosed.transform.localScale = new Vector2(0, 0);
                dooropen.transform.localScale = new Vector2(1, 1);
                CombatActive = false;
                RoomDone = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (RoomDone == false && CombatActive == false)
        {
            if (collision.CompareTag("Player"))
            {
                doorclosed.transform.localScale = new Vector2(1, 1);
                dooropen.transform.localScale = new Vector2(0, 0);
                CombatActive = true;
                Debug.Log("Room Event Triggered");
                // Summon enemies
                for (int i = 0; i < RoomEnemyCount; i++)
                {
                    // Spawns enemies at a random SpawnPoint
                    Vector2 spawnPosition = SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position;

                    // Instantiate an enemy at the calculated position
                    Instantiate(roomEnemyPrefab, spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}