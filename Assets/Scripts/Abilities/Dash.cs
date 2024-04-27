using UnityEngine;

public class Dash : MonoBehaviour, IGlobalEvents
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] EventHandler eventHandler;

    [SerializeField] private float dashSpeed;

    public EventHandler EHandler => eventHandler;

    const string PLAYER = "Player";

    private void Start()
    {
        _rigidbody = GameObject.FindGameObjectWithTag(PLAYER).GetComponent<Rigidbody2D>();
    }

    public void Ready()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rigidbody.gravityScale = 0;
            EHandler.SetEvent(Events.active);
        }
    }

    public void Active()
    {
        _rigidbody.velocity = Vector2.right * dashSpeed * _rigidbody.transform.localScale.x;
    }

    public void Cooldown()
    {
        _rigidbody.gravityScale = 1;
    }
}
