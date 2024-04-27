using UnityEngine;

public class LessGravity : MonoBehaviour, IGlobalEvents
{
    [SerializeField] EventHandler eventHandler;
    [SerializeField] Rigidbody2D _rigidbody;

    [SerializeField] private float newGravityScale;

    public EventHandler EHandler => eventHandler;

    const string PLAYERTAG = "Player";

    void Start()
    {
        _rigidbody = GameObject.FindGameObjectWithTag(PLAYERTAG).GetComponent<Rigidbody2D>();
    }

    public void Ready()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rigidbody.gravityScale = newGravityScale;
            EHandler.SetEvent(Events.active);
        }
    }

    public void Active() {}

    public void Cooldown()
    {
        if (_rigidbody.gravityScale == 1) return;
        _rigidbody.gravityScale = 1;
    }
}
