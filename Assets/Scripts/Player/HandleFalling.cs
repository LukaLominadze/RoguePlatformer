using UnityEngine;

public class HandleFalling : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] private float fallMultiplier;
    [SerializeField] private float short_fallMultiplier;

    private float gravity;

    private bool jumpInput;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        gravity = Physics2D.gravity.y;
    }

    void Update()
    {
        jumpInput = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        //accelerate falling after jump
        if (_rigidbody.velocity.y < 0)
        {
            AccelerateFall(fallMultiplier);
        }
        //accelerate faster when letting go of jump mid-air
        else if (_rigidbody.velocity.y > 0 && !jumpInput)
        {
            AccelerateFall(short_fallMultiplier);
        }
    }

    private void AccelerateFall(float acceleration)
    {
        _rigidbody.velocity += Vector2.up * gravity * acceleration * Time.fixedDeltaTime;
    }
}
