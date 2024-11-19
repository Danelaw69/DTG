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
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("OptionsMenu").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Image").transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscapeMenuActive == false)
            {
                GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(1, 1);
                GameObject.Find("Image").transform.localScale = new Vector2(1, 1);
                EscapeMenuActive = true;
                Time.timeScale = 0;
            }
            else
            {
                GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(0, 0);
                GameObject.Find("Image").transform.localScale = new Vector2(0, 0);
                GameObject.Find("OptionsMenu").transform.localScale = new Vector2(0, 0);
                EscapeMenuActive = false;
                Time.timeScale = 1;
            }


        }
    }
    public void doResumeGame()
    {
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Image").transform.localScale = new Vector2(0, 0);
        EscapeMenuActive = false;
        Time.timeScale = 1;
    }
    public void doOptions()
    {
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("OptionsMenu").transform.localScale = new Vector2(1, 1);
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
