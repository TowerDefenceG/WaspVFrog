using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    // public GameObject backButton;
    // public GameObject retryButton;
    // public GameObject levelSelectBtn;
    // public GameObject continueBtn;
    public GameObject ui;


    public void Retry()
    {
        PlayerStats.Rounds = 0;
        Debug.Log(PlayerStats.Rounds);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //change to next level later
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene(9);
        // Time.timeScale = 1f;
    }

    public void Back(){
        Time.timeScale = 1f;
        ui.SetActive(false);
    }
}
