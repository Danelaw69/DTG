using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame.playerHealth;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("End Screen Buttons").transform.localScale = new Vector2(0, 0);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.playerAlive == false)
        {
            Time.timeScale = 0;
            GameObject.Find("End Screen Buttons").transform.localScale = new Vector2(1, 1);
        }
    }
    public void doRestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void doMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
