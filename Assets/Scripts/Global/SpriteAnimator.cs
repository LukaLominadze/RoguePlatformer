using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] SpriteAnimation[] animations;

    Dictionary<string, SpriteAnimation> animDict = new Dictionary<string, SpriteAnimation>();

    private string currentAnim;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        for (int i = 0; i < animations.Length; i++)
        {
            animDict.Add(animations[i].animName, animations[i]);
        }

        currentAnim = animations[0].animName;

        StartCoroutine(PlayAnimation());
    }

    public void ChangeAnimationState(string newState)
    {
        if (newState == currentAnim)
        {
            return;
        }
        else
        {
            currentAnim = newState;
            RestartAnimation();
        }
    }

    private void RestartAnimation()
    {
        StopCoroutine(PlayAnimation());
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        Sprite[] animation = animDict[currentAnim].anim.ToArray();

        for (int i = 0; i < animation.Length; i++)
        {
            spriteRenderer.sprite = animation[i];

            yield return new WaitForSeconds(animDict[currentAnim].animLength / animation.Length);
        }

        if (animDict[currentAnim].loop)
        {
            RestartAnimation();
        }
    }
}
