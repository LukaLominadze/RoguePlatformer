using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] Collision collision;
    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] private float jumpForce;

    private bool jumpInput;
    private bool hasJumped = false;

    void Start()
    {
        collision = GetComponent<Collision>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jumpInput = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
        //only allow player to jump, when on ground
        if (collision.OnGround())
        {
            hasJumped = false;
            if (jumpInput && !hasJumped)
            {
                _rigidbody.AddForce(Vector2.up * jumpForce * Mathf.Sign(_rigidbody.gravityScale),
                                    ForceMode2D.Impulse);
                hasJumped = true;
            }
        }
    }
}
