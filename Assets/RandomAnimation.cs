using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : MonoBehaviour
{
    public Animator animator;
    private AnimationClip[] clips;
    
    
    void Awake()
    {
        clips = animator.runtimeAnimatorController.animationClips;
    }

    private void Start()
    {
        StartCoroutine(PlayRandomly());
    }
    private IEnumerator PlayRandomly ()
    {
        while(true)
        {
            var randInd = Random.Range(0, clips.Length);

            var randClip = clips[randInd];

            animator.Play(randClip.name);

            // Wait until animation finished than pick the next one
            yield return new WaitForSeconds(randClip.length);
        }
    }
}
