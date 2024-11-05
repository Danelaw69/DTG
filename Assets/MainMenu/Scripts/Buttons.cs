using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Options").transform.localScale = new Vector2(0, 0);
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
        GameObject.Find("Buttons").transform.localScale = new Vector2(0, 0);
        GameObject.Find("Options").transform.localScale = new Vector2(1, 1);

    }
    public void doBack()
    {
        GameObject.Find("Buttons").transform.localScale = new Vector2(1, 1);
        GameObject.Find("Options").transform.localScale = new Vector2(0, 0);
    }
    public void doStartGame()
    {
        SceneManager.LoadScene(1);
    }
}
