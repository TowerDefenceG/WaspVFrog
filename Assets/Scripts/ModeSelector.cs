using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDifficulty {
    // 0 to 1
    public float enemySpeedFactor;
    // 0 to 1
    public float waveSizeFactor;
    // 0 to 1
    public float timeBetweenWavesFactor;
    // 0 to 1
    public float enemyTypeFactor;
}


public class ModeSelector : MonoBehaviour
{
    public static int difficulty=1;
    public Button easyButton = null;
    public Button hardButton = null;
    public Button insaneButton = null;

    public static GameDifficulty GetDifficulty(){
        GameDifficulty gd = new GameDifficulty();
        switch(difficulty){
            case 1:
                gd.enemySpeedFactor = 1f;
                gd.waveSizeFactor = 1f;
                gd.timeBetweenWavesFactor = 1f;
                gd.enemyTypeFactor = 1f;
                break;
            case 2:
                gd.enemySpeedFactor = 1.5f;
                gd.waveSizeFactor = 1.3f;
                gd.timeBetweenWavesFactor = 0.7f;
                gd.enemyTypeFactor = 1.3f;
                break;
            case 3:
                gd.enemySpeedFactor = 2f;
                gd.waveSizeFactor = 1.7f;
                gd.timeBetweenWavesFactor = 0.5f;
                gd.enemyTypeFactor = 2.0f;
                break;
        }
        //Debug.Log("GetDifficulty() difficulty=" + difficulty + " with factors enemySpeedFactor=" + gd.enemySpeedFactor + " waveSizeFactor=" + gd.waveSizeFactor + " timeBetweenWavesFactor=" + gd.timeBetweenWavesFactor + " " + gd.enemyTypeFactor);
        return gd;
    }

    public void SelectEasy(){
        difficulty=1;
        Debug.Log("difficulty set to " + difficulty);
    }
    public void SelectHard(){
        difficulty=2;
        Debug.Log("difficulty set to " + difficulty);
    }
    public void SelectInsane(){
        difficulty=3;
        Debug.Log("difficulty set to " + difficulty);
    }

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch(difficulty){
            case 1:
                easyButton?.Select();
                break;
            case 2:
                hardButton?.Select();
                break;
            case 3:
                insaneButton?.Select();
                break;
        }
    }
}
