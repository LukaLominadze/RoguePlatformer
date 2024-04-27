using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Animator animator;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float decceleration;
    [SerializeField] private float velocityPower;

    private float direction;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //flip the character depending on which direction the player is moving in
        if (direction != 0) transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);

        // Get the desired speed, A.K.A max possible speed
        float targetSpeed = direction * movementSpeed * animator.speed;
        // Get the difference between the current speed and the desired speed
        float speedDifference = targetSpeed - _rigidbody.velocity.x;
        // Deccelerate or accelerate based on how fast we are moving
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        // Calculate the final speed
        float movement = Mathf.Pow(Mathf.Abs(speedDifference) * accelRate, velocityPower) * Mathf.Sign(speedDifference);

        _rigidbody.AddForce(movement * Vector2.right);
    }
}
