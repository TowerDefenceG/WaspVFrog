// tutorial from Brackeys: https://www.youtube.com/watch?v=-cTgL9jhpUQ&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=27
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLevelPCG()
    {
        SceneManager.LoadScene(4);
    }
}
