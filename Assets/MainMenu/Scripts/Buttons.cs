using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Test").transform.localScale = new Vector2(0, 0);
        GameObject.Find("BackButton").transform.localScale = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void doOptions()
    {
        GameObject.Find("StartButton").transform.localScale = new Vector2(0, 0);
        GameObject.Find("OptionsButton").transform.localScale = new Vector2(0, 0);
        GameObject.Find("ExitButton").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Test").transform.localScale = new Vector2(3, 3);
        GameObject.Find("BackButton").transform.localScale = new Vector2(3, 3);

    }
    public void doBack()
    {
        GameObject.Find("StartButton").transform.localScale = new Vector2(3, 3);
        GameObject.Find("OptionsButton").transform.localScale = new Vector2(3, 3);
        GameObject.Find("ExitButton").transform.localScale = new Vector2(3, 3);
        GameObject.Find("Test").transform.localScale = new Vector2(0, 0);
        GameObject.Find("BackButton").transform.localScale = new Vector2(0, 0);
    }
    public void doStartGame()
    {
        SceneManager.LoadScene(0);
    }
}
