using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] private float topSpeed;
    [SerializeField] private float lerpTime;

    private float currentSpeed = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, topSpeed, lerpTime * Time.fixedDeltaTime);

        _rigidbody.velocity = transform.right * currentSpeed;
    }
}
