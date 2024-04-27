using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] AnimationHandler animHandler;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Collision collision;

    // Animation states
    const string IDLE = "Player_Idle";
    const string RUN = "Player_Run";
    const string JUMP = "Player_Jump";
    const string FALL = "Player_Fall";

    private void Start()
    {
        animHandler = GetComponent<AnimationHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Mid-air animations
        if (!collision.OnGround())
        {
            if(_rigidbody.velocity.y > 0.01f)
            {
                animHandler.ChangeAnimationState(JUMP);
            }
            else
            {
                animHandler.ChangeAnimationState(FALL);
            }
            return;
        }
        // Ground animations
        if (Mathf.Abs(_rigidbody.velocity.x) < 0.01f)
        {
            animHandler.ChangeAnimationState(IDLE);
        }
        else
        {
            animHandler.ChangeAnimationState(RUN);
        }
    }
}
