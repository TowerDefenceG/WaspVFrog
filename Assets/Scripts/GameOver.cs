using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;
    public TextMeshProUGUI moneyText;

    void OnEnable() {
        roundsText.text = (PlayerStats.Rounds-1).ToString();
        moneyText.text = "£"+(PlayerStats.Money).ToString();

    }
    public void Retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }
}
