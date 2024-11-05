using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        {

        }
    }
}
