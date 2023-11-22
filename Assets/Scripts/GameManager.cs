using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public static bool levelWon;
    public GameObject gameOverUI;
    public GameObject levelWonUI;
    public int waveSurvived = 5;

    void Start(){
        gameIsOver = false;
        levelWon = false;
    }
    void Update(){
        if(gameIsOver || levelWon){
            return;
        }
        // if(Input.GetKeyDown("e")){
        //     EndGame();
        // }

        if(PlayerStats.Lives <= 0){
            EndGame();
        }
        if(PlayerStats.Rounds >= waveSurvived){
            WonLevel();
        }

    }

    void EndGame(){
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    void WonLevel(){
        levelWon = true;
        levelWonUI.SetActive(true);
    }
}
