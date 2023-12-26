using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinLevel : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    void OnEnable(){
        roundsText.text = PlayerStats.Rounds.ToString();
    }
    public void Continue(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //change to next level later
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }
 
}
