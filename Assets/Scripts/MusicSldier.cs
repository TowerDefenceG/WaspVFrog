using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSldier : MonoBehaviour
{
    [SerializeField] private Slider _musicslider;
    [SerializeField] private Button musicOn;
    [SerializeField] private Button musicOff;
    [SerializeField] private GameObject musicOnImg;
    [SerializeField] private GameObject musicOffImg;
    // Start is called before the first frame update
    void Start()//starting with musicOn button and image being active
    {
        musicOn.enabled = true;
        musicOnImg.gameObject.SetActive(true);
        _musicslider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMusicVolume(val));//checking for slider value and changing volume to match
    }

    public void Update(){//when the slider is at 0 the img swithces to the musicoff
        if (_musicslider.value == 0){
            musicOffImg.gameObject.SetActive(true);
            musicOnImg.gameObject.SetActive(false);
        }
        else{
        musicOnImg.gameObject.SetActive(true);
        musicOffImg.gameObject.SetActive(false);
        }
    }

}
