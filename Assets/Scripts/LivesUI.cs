using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class LivesUI : MonoBehaviour
{
    public Text livesTexts;

    private static TMPro.TextMeshProUGUI livesT;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LivesUI.Start()");
        //Transform child =  transform.Find("HealthText");
        //Debug.Log(child);
        livesT = GetComponent<TMPro.TextMeshProUGUI>();
        //Debug.Log(livesT);
        
       // livesText.text = PlayerStats.Lives.ToString() + " LIVES";
       //transform.text = "trial LIVES";    
        
    }

    // Update is called once per frame
    void Update()
    {
        livesT.text =   PlayerStats.Lives.ToString() + " LIVES";  
    }

    
}
