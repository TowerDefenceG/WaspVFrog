using UnityEngine;

public class StartAnimationAtRandomFrame : MonoBehaviour{
    private Animation _animation;
    private AnimationClip defaultClip;

    void Start(){
        _animation = GetComponent<Animation>();

        // Get the default animation clip
        defaultClip = _animation.clip;

        // Play the default animation at a random frame
        PlayDefaultAnimationAtRandomFrame();
    }

    void PlayDefaultAnimationAtRandomFrame(){
        if (defaultClip != null){
            // Play the default animation
            _animation.Play();

            // Set the time to a random value within the animation duration
            float randomTime = Random.Range(0f, defaultClip.length);
            _animation[defaultClip.name].time = randomTime;
        }else{
            Debug.LogWarning("No default animation clip found.");
        }
    }
}