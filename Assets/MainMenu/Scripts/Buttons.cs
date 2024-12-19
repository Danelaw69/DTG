using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public bool OptionsMenuActive = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("View Controls Menu").transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || OptionsMenuActive == false)
        {
            GameObject.Find("Buttons").transform.localScale = new Vector2(1, 1);
            GameObject.Find("View Controls Menu").transform.localScale = new Vector2(0, 0);
            OptionsMenuActive = true;
        }
    }
    public void doStartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void doControlsMenu()
    {
        GameObject.Find("Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("View Controls Menu").transform.localScale = new Vector2(1, 1);
        OptionsMenuActive = true;

    }
    public void doBack()
    {
        GameObject.Find("Buttons").transform.localScale = new Vector2(1, 1);
        GameObject.Find("View Controls Menu").transform.localScale = new Vector2(0, 0);
        OptionsMenuActive = false;
    }
}
