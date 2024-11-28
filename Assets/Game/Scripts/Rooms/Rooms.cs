using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.rooms
{

    public class Rooms : MonoBehaviour
    {
        // Intergars
        public int RoomNumber;
        public int RoomEnemyCount;
        public int RoomEnemiesAlive;

        // Bools
        public bool RoomDone = false;
        public bool CombatActive = false;

        // Attach References
        public GameObject roomEnemyPrefab; // Prefab for enemies
        public GameObject doorclosed;
        public GameObject dooropen;
        public GameObject HellenHealthBar;
        public GameObject[] SpawnPoints;


        // Start is called before the first frame update
        private void Awake()
        {
            HellenHealthBar = GameObject.FindWithTag("Boss Health Bar");
        }
        void Start()
        {
            doorclosed = GameObject.FindWithTag("Door closed");
            dooropen = GameObject.FindWithTag("Door open");
            doorclosed.transform.localScale = new Vector2(0, 0);
            HellenHealthBar.transform.localScale = new Vector2(0, 0);
        }

        // Update is called once per frame

        void Update()
        {

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
                        RoomEnemiesAlive = RoomEnemyCount;
                        CombatActive = true;
                        // Summon enemies
                        for (int i = 0; i < RoomEnemyCount; i++)
                        {
                            // Spawns enemies at a random SpawnPoint
                            Vector2 spawnPosition = SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position;

                            // Instantiate an enemy at the calculated position
                            Instantiate(roomEnemyPrefab, spawnPosition, Quaternion.identity);
                        }

                    }
                    if (RoomNumber == 2)
                    {

                    }
                    if (RoomNumber == 3)
                    {
                        doorclosed.transform.localScale = new Vector2(1, 1);
                        dooropen.transform.localScale = new Vector2(0, 0);
                        HellenHealthBar.transform.localScale = new Vector2(1, 1);
                        RoomEnemiesAlive = RoomEnemyCount;
                        CombatActive = true;
                        for (int i = 0; i < RoomEnemyCount; i++)
                        {
                            // Spawns enemies at a random SpawnPoint
                            Vector2 spawnPosition = SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position;

                            // Instantiate an enemy at the calculated position
                            Instantiate(roomEnemyPrefab, spawnPosition, Quaternion.identity);

                        }
                    }
                    Debug.Log("Room event Triggered");
                }
            }
        }
    }
}