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
        HideAllButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscapeMenuActive == false)
            {
                ToggleOnEscapeMenu();
            }
            else
            {
                ToggleOffEscapeMenu();
            }


        }
    }
    public void doResumeGame()
    {
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Menu Background").transform.localScale = new Vector2(0, 0);
        EscapeMenuActive = false;
        Time.timeScale = 1;
    }
    public void doOptions()
    {
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Options Menu Buttons").transform.localScale = new Vector2(1, 1);
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
    public void doViewControlsBack()
    {
        GameObject.Find("View Controls Menu").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(1, 1);
    }
    public void doViewControls()
    {
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("View Controls Menu").transform.localScale = new Vector2(1, 1);
    }
    public void HideAllButtons()
    {
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Menu Background").transform.localScale = new Vector2(0, 0);
        GameObject.Find("View Controls Menu").transform.localScale = new Vector2(0, 0);
    }
    public void ToggleOnEscapeMenu()
    {
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(1, 1);
        GameObject.Find("Menu Background").transform.localScale = new Vector2(1, 1);
        EscapeMenuActive = true;
        Time.timeScale = 0;
    }
    public void ToggleOffEscapeMenu()
    {
        GameObject.Find("Escape Menu Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Menu Background").transform.localScale = new Vector2(0, 0);
        GameObject.Find("View Controls Menu").transform.localScale = new Vector2(0, 0);
        EscapeMenuActive = false;
        Time.timeScale = 1;
    }
}
