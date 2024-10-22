using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Test").transform.localScale = new Vector3(0, 0, 0);
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
        GameObject.Find("StartButton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("OptionsButton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("ExitButton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("Test").transform.localScale = new Vector3(1, 1, 1);
    }
    public void doBack()
    {
        GameObject.Find("StartButton").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("OptionsButton").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("ExitButton").transform.localScale = new Vector3(1, 1, 1);
        GameObject.Find("Test").transform.localScale = new Vector3(0, 0, 0);
    }
    public void doStartGame()
    {
        SceneManager.LoadScene(0);
    }
}
