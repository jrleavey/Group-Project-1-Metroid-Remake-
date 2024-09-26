using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _pausemenu;
    public GameObject _loseMenu;
    public GameObject _winMenu;
    public bool _isPauseMenuOpen = false;

    private void Awake()
    {
        Time.timeScale = 1;
    }

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
        SceneManager.LoadScene("Lvl 1");
        Time.timeScale = 1;
    }

    public void AboutButton()
    {
        SceneManager.LoadScene("AboutCredits");
    }

    public void Main()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
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