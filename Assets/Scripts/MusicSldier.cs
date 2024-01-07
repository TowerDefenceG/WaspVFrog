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
    void Start()
    {
        musicOn.enabled = true;
        musicOnImg.gameObject.SetActive(true);
        _musicslider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMusicVolume(val));
    }

    public void Update(){
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
