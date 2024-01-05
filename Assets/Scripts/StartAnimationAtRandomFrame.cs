using UnityEngine;

// https://www.youtube.com/watch?time_continue=74&v=j8GsxIyJUVw&embeds_referring_euri=https%3A%2F%2Fwww.google.com%2F&source_ve_path=Mjg2NjY&feature=emb_logo

public class StartAnimationAtRandomFrame : MonoBehaviour
{
    private Animator _animator;
    void Start(){
        _animator = GetComponent<Animator>();
        var state = _animator.GetCurrentAnimatorStateInfo(0);
        _animator.Play(state.fullPathHash, 0, Random.Range(0f,1f));
    }
}
