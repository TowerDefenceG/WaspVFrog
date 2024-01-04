using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinLevel : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI highestScore;
    int total;

    

    void Start(){
        total = 0;
        highestScore.text = PlayerPrefs.GetInt("HighestScores", 0).ToString();
    }

    void OnEnable(){
        roundsText.text = PlayerStats.Rounds.ToString();
        moneyText.text = "£"+(PlayerStats.Money).ToString();
        livesText.text = (PlayerStats.Lives).ToString();
        total = PlayerStats.Money + PlayerStats.Rounds*5 + PlayerStats.Lives*20;
        totalScore.text = total.ToString();

        if (total > PlayerPrefs.GetInt("HighestScores",0))
        {
            PlayerPrefs.SetInt("HighestScores", total);
            highestScore.text = total.ToString();
        }
    }
    public void Continue(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //change to next level later
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }
 
}
