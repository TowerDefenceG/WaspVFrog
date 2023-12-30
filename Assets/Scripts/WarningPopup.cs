using System.Collections;
using UnityEngine;

public class WarningPopup : MonoBehaviour{
    public GameObject popupPanel;

    void Start(){
        Debug.Log("warning popup start");
        HidePopup();
    }

    public void ShowPopup(){   
        Debug.Log("show popup");
        popupPanel.SetActive(true);
        StartCoroutine(HidePopupAfterDelay(0.5f));
    }

    IEnumerator HidePopupAfterDelay(float delay){
        yield return new WaitForSeconds(delay);
        HidePopup();
    }

    void HidePopup(){
        popupPanel.SetActive(false);
    }
}