using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModeSelector : MonoBehaviour
{
    public static int difficulty=1;
    public Button easyButton = null;
    public Button hardButton = null;
    public Button insaneButton = null;

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
