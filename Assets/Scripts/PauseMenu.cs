using UnityEngine;
using UnityEngine.SceneManagement; //used to load/reload scenes

public class PauseMenu : MonoBehaviour
{

    public GameObject ui;

   void Update(){
    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)){
        Toggle();
    }
   }

   public void Toggle(){
        ui.SetActive(!ui.activeSelf); //inverts current state

        if(ui.activeSelf){
            //pause menu enabled
            //freeze time
            Time.timeScale = 0f; 
            // Time.fixedDeltaTime = 0f; // use if speeding up/ slowing down 
        }else{
            Time.timeScale = 1f; //unpause 
        }
   }

   public void Retry(){
        // reload current scene
        Toggle(); //unpause 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        // SceneManager.LoadScene(1);
   }

   public void Menu(){
        SceneManager.LoadScene(0);
   }
}
