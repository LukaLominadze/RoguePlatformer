using UnityEngine;

public class ThrowableWithMass : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] private float throwableSpeed;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(transform.right * throwableSpeed, ForceMode2D.Impulse);
    }
}
