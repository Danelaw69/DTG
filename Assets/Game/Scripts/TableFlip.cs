using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFlip : MonoBehaviour
{
    // Assign these in the Inspector
    public GameObject objectToHide;
    public GameObject objectToHide2;
    public GameObject objectToHide3;
    public GameObject objectToHide4;
    public GameObject objectToReveal;

    private void Start()
    {
        
    }
    private void OnTriggerStay2D (Collider2D other)
    { 
        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Flipped");
                SwapObjects();
            }
        }
    }
    public void SwapObjects()
    {
        // Hide the first object
        objectToHide.SetActive(false);
        objectToHide2.SetActive(false);
        objectToHide3.SetActive(false);
        objectToHide4.SetActive(false);

        // Reveal the second object
        objectToReveal.SetActive(true);
    }
}