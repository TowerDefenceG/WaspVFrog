using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSldier : MonoBehaviour
{
    [SerializeField] private Slider _musicslider;
    // Start is called before the first frame update
    void Start()
    {
        _musicslider.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMusicVolume(val));
    }


}
