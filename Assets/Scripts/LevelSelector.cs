// tutorial from Brackeys: https://www.youtube.com/watch?v=-cTgL9jhpUQ&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=27
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }
}