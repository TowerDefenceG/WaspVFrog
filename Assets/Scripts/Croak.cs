using UnityEngine;
using System.Collections;

public class Croak : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;

    public AudioClip frogSound;

    private float croakInterval = 10f; // Time interval between croaks

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        // Start the Croak coroutine
        StartCoroutine(CroakRoutine());
    }

    // Coroutine to play croak animation and frog sound repeatedly
    private IEnumerator CroakRoutine()
    {
        while (true)
        {
            // Play croak animation and frog sound simultaneously
            PlayCroakAnimation();
            PlayFrogSound();

            // Wait for the specified time interval
            yield return new WaitForSeconds(croakInterval);
        }
    }

    // Play the "croak" animation
    private void PlayCroakAnimation()
    {
        if (_animator != null)
        {
            var state = _animator.GetCurrentAnimatorStateInfo(0);
            _animator.Play(state.fullPathHash, 0, Random.Range(0f, 1f));
        }
    }

    // Play the "frog" sound
    private void PlayFrogSound()
    {
        if (_audioSource != null && frogSound != null)
        {
            _audioSource.clip = frogSound;
            _audioSource.Play();
        }
    }
}
