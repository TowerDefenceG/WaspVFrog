// tutorial from Brackeys: https://youtu.be/pZ0QyngaQv4?si=8p7v54hAiPu2_egk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerStats : MonoBehaviour
{
    public static int Money; //accessible only using playerstats type
    public int startMoney = 400; //accessible in unity editor
    public static int Lives;
    public int startLives = 5;
    public static int Rounds;
    public TextMeshProUGUI moneyText;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    public List<GameObject> hearts;

    public static PlayerStats Instance;

    void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject); // If an instance already exists, destroy this one
        }
    } 

    void Start(){
        Money = startMoney;
        Lives = startLives;
        hearts = new List<GameObject> { life1, life2, life3, life4, life5 };
        Rounds = 0;
        ActivateAllHearts();

    }

    void Update(){
         moneyText.text = (Money.ToString() ); //change to whatever currency we want, maybe an icon
    }
    
    public static void decreaseLives(){
        if (Instance != null){
            if (Lives > 0){
                Lives--;
                Instance.LoseHeart();
            }
            if (Lives==0){
                Debug.Log("game over");
            }
        }
    }

    void LoseHeart(){
        for (int i = hearts.Count - 1; i >= 0; i--){
            if (hearts[i].activeSelf)
            {
                hearts[i].SetActive(false);
                break; // Stop after deactivating the first active heart
            }
        }
    }

    void ActivateAllHearts(){
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
    }
}
