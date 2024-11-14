using UnityEngine;

public class HellenAttackSpin : MonoBehaviour
{
    public GameObject shotPrefab;
    public int shotCount;
    public float shotSpeed;
    public float shotSpread;

    void Start()
    {
        // Launch the shots
        for (int i = 0; i < shotCount; i++)
        {
            // Calculate a random angle within the spread
            float angle = Random.Range(0, 360); // Random angle from 0 to 360 degrees

            // Instantiate a shot at the BOSS's position:
            GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.Euler(0, 0, angle));

            // Set the shot's initial velocity
            shot.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, angle) * Vector2.right * shotSpeed;
        }

        // Destroy the attack object after launching shots
        Destroy(gameObject);
    }
}