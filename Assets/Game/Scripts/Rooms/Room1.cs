using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour
{
    // Bools
    public bool RoomDone = false;
    public bool CombatActive = false;

    // Attach References
    public GameObject enemyPrefab; // Prefab for enemies


    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Room 1").transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (CombatActive == false)
        {
            GameObject.Find("Room 1").transform.localScale = new Vector2(0, 0); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (RoomDone == false)
        {
            if (collision.CompareTag("Player"))
            {
                GameObject.Find("Room 1").transform.localScale = new Vector2(1, 1);
                CombatActive = true;
                Debug.Log("Room event Triggered");
            }
        }
    }
}
