using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    void OnEnable() {
        roundsText.text = PlayerStats.Rounds.ToString();
    }
    // public void Retry(){
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    // }
    // public void Menu(){
    //     Debug.Log("Go to menu.");
    // }
}
