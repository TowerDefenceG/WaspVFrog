//tutorial from Tarodev link:https://www.youtube.com/watch?v=tEsuLTpz_DU
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;

    void Awake(){
        if (Instance==null){
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else{
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip){
        _effectsSource.PlayOneShot(clip);
    }

    public void ChangeMusicVolume(float value){
        _musicSource.volume = value;
    }

    public void ChangeEffectsVolume(float value){
        _effectsSource.volume = value;
    }
}
