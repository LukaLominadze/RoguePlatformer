using System.Collections.Generic;
using UnityEngine;

public class ArrowHolder : MonoBehaviour
{
    [SerializeField] private float animationTime;

    [SerializeField] List<Arrow> arrows = new List<Arrow>();

    private void Start()
    {
        // Get the animation length
        animationTime = arrows[0].gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }

    public void ShootArrows(float force, float damage, float knockback, string targetTag)
    {
        // Shoot the arrow (Take into account that there might be multiple arrows thrown)
        foreach(Arrow arrow in arrows)
        {
            arrow.ShootArrow(force, damage, knockback, targetTag);
        }        

        // Destroy the arrows holder after the arrow has been stripped off of the arrow holder
        Destroy(gameObject);
    }

    public float GetAnimationTime()
    {
        return animationTime;
    }
}
