using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escapemenu : MonoBehaviour
{
    public bool EscapeMenuActive = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(0, 0);
        GameObject.Find("Image").transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscapeMenuActive == false)
            {
                GameObject.Find("Resume").transform.localScale = new Vector2(3, 3);
                GameObject.Find("Options").transform.localScale = new Vector2(3, 3);
                GameObject.Find("Exit").transform.localScale = new Vector2(3, 3);
                GameObject.Find("Image").transform.localScale = new Vector2(3, 3);
                GameObject.Find("Main Menu").transform.localScale = new Vector2(3, 3);
                EscapeMenuActive = true;
                Time.timeScale = 0;
            }
            else
            {
                GameObject.Find("Resume").transform.localScale = new Vector2(0, 0);
                GameObject.Find("Options").transform.localScale = new Vector2(0, 0);
                GameObject.Find("Exit").transform.localScale = new Vector2(0, 0);
                GameObject.Find("Image").transform.localScale = new Vector2(0, 0);
                GameObject.Find("Button").transform.localScale = new Vector2(0, 0);
                GameObject.Find("Main Menu").transform.localScale = new Vector2(0, 0);
                EscapeMenuActive = false;
                Time.timeScale = 1;
            }


        }
    }
    public void doResumeGame()
    {
        GameObject.Find("Resume").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Options").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Exit").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Image").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Main Menu").transform.localScale = new Vector2(0, 0);
        EscapeMenuActive = false;
        Time.timeScale = 1;
    }
    public void doOptions()
    {
        GameObject.Find("Resume").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Options").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Exit").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Main Menu").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Button").transform.localScale = new Vector2(3, 3);
    }
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void doMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        EscapeMenuActive = false;
    }
}
