// tutorial from Brackeys: https://www.youtube.com/watch?v=-cTgL9jhpUQ&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=27
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadStartMenue()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadLevel1()
    {
        LevelGenerator.SetLevel(1);
        SceneManager.LoadScene(6);
    }
    public void LoadLevel2()
    {
        LevelGenerator.SetLevel(2);
        SceneManager.LoadScene(7);
    }

    public void LoadLevel3()
    {
        LevelGenerator.SetLevel(3);
        SceneManager.LoadScene(8);
    }

}
