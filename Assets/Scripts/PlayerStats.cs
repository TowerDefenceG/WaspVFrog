using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerStats : MonoBehaviour
{
    public static int Money; //accessible only using playerstats type
    public int startMoney = 400; //accessible in unity editor

    public TextMeshProUGUI moneyText;
       

    void Start(){
        Money = startMoney;

    }

    void Update(){
         moneyText.text = ("£" + Money.ToString() ); //change to whatever currency we want, maybe an icon
    }
}
