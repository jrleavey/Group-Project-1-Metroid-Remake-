using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _pausemenu;
    public bool _isPauseMenuOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isPauseMenuOpen == false)
        {
            isPaused();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && _isPauseMenuOpen == true))
        {
            isNotPaused();
        }
    }
    public void ExitButton() { 
        Application.Quit();
    }

    public void StartButton() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lvl 1");
    }

    public void AboutButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("AboutCredits");
    }

    public void Main()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void isPaused()
    {
        _isPauseMenuOpen = true;
        _pausemenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void isNotPaused()
    {
        _isPauseMenuOpen = false;
        _pausemenu.SetActive(false);
        Time.timeScale = 1;
    }

}