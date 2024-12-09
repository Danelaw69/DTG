using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("End Screen Buttons").transform.localScale = new Vector2(0, 0);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void doRestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void DoRestartGame1()
    {
        SceneManager.LoadScene(2);
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
