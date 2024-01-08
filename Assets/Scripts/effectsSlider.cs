using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectsSlider : MonoBehaviour
{   [SerializeField] private Slider _effectsslider;
    [SerializeField] private Button effectsOn;
    [SerializeField] private Button effectsOff;
    [SerializeField] private GameObject effectsOnImg;
    [SerializeField] private GameObject effectsOffImg;
    // Start is called before the first frame update
    void Start()//defaults effects buttons to on
    {
        effectsOn.enabled = true;
        effectsOnImg.gameObject.SetActive(true);
        _effectsslider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeEffectsVolume(val));//checking for slider change and changing volume to match
    }
    public void Update(){
        if (_effectsslider.value == 0){//switches to the no sound button image when the slider is 0
            effectsOffImg.gameObject.SetActive(true);
            effectsOnImg.gameObject.SetActive(false);
        }
        else{
        effectsOnImg.gameObject.SetActive(true);
        effectsOffImg.gameObject.SetActive(false);
        }
    }

}

