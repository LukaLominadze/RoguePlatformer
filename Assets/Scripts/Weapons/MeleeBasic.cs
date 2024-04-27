using UnityEngine;

public class MeleeBasic : MonoBehaviour, IGlobalEvents
{
    [SerializeField] EventHandler eventHandler;
    [SerializeField] Animator animator;

    [SerializeField] private string idleAnim;
    [SerializeField] private string attackAnim;

    private bool input;

    public EventHandler EHandler => eventHandler;

    private void Update()
    {
        input = Input.GetKey(KeyCode.Mouse0);
    }

    public void Ready()
    {
        // Listen for input
        if(input)
        {
            // Play the sword animation
            animator.Play(attackAnim);
            EHandler.SetEvent(Events.active);
        }
    }

    public void Active()
    {
    }

    public void Cooldown()
    {
        animator.Play(idleAnim);
    }
}
