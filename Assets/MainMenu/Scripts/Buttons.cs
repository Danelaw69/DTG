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
        GameObject.Find("Options").transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || OptionsMenuActive == false)
        {
            GameObject.Find("Buttons").transform.localScale = new Vector2(1, 1);
            GameObject.Find("Options").transform.localScale = new Vector2(0, 0);
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
    public void doOptions()
    {
        GameObject.Find("Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Options").transform.localScale = new Vector2(1, 1);
        OptionsMenuActive = true;

    }
    public void doBack()
    {
        GameObject.Find("Buttons").transform.localScale = new Vector2(1, 1);
        GameObject.Find("Options").transform.localScale = new Vector2(0, 0);
        OptionsMenuActive = false;
    }
    public void doControls()
    {
        GameObject.Find("Options").transform.localScale = new Vector2(0, 0);
    }
}
