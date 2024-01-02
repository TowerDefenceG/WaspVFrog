using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectsSlider : MonoBehaviour
{
    [SerializeField] private Slider _effectsslider;
    // Start is called before the first frame update
    void Start()
    {
        _effectsslider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeEffectsVolume(val));
    }


}

