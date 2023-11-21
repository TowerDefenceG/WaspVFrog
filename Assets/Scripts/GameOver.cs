using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    void OnEnable() {
        roundsText.text = (PlayerStats.Rounds).ToString();
    }
    public void Retry(){
        SceneManager.LoadScene(1);
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }
}
