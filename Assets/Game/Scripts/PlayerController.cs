using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movmentSpeed = 2f;

    public float dashRange = 5f;
    public float dashSpeed = 1.0f;
    public float dashCooldown = 1.0f;

    private float activeMoveSpeed;
    private float dashCounter;
    private float dashCoolCounter;

    private Rigidbody2D rb;

    private Vector2 movementDirection;


    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = movmentSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashRange;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = movmentSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movementDirection * activeMoveSpeed;
    }
}
