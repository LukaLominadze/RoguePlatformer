using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    // This will be used to check which animation will be currently playing
    private string currentState = "";

    private Dictionary<string, float> clipInfos = new Dictionary<string, float>();

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        // Check if the passed in animation is already playing so we don't restart it
        if (currentState == newState) return;

        animator.Play(newState);
        currentState = newState;
    }

    public void CreateClipInfos()
    {
        foreach(AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            clipInfos.Add(clip.name, clip.length);
        }
    }

    public float GetClipTime(string clip)
    {
        return clipInfos[clip];
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
