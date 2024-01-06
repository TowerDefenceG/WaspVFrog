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
        // rounds start at 1...
        if(PlayerStats.Rounds > waveSurvived+1){
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

    public void ToggleSpeed(){
        if(Time.timeScale == 1){
            Time.timeScale = 2f;
            Time.fixedDeltaTime = 2f;
        }else if(Time.timeScale == 2){
            Time.timeScale = 1f; 
            Time.fixedDeltaTime = 1f; // use if speeding up/ slowing down 
        }
    }
}
