using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScreen : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Win Screen").transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Loads Game Scene
    public void doRestartGame()
    {
        SceneManager.LoadScene(1);
    }
    // Loads Main Menu Scene and sets TimeScale to 1
    public void doMainMenuWin()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    // Quits Program and Puts "Game Closed" in Debug Log
    public void doExitGameWin()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
