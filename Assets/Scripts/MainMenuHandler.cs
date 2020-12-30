using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LevelSelection()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
}
