using UnityEngine;

public class FlipGravity : MonoBehaviour, IGlobalEvents
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] EventHandler eventHandler;

    public EventHandler EHandler => eventHandler;

    const string PLAYERTAG = "Player";

    void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag(PLAYERTAG).GetComponent<Rigidbody2D>();
    }

    public void Ready()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerBody.gravityScale *= -1;
            EHandler.SetEvent(Events.active);
        }
    }

    public void Active()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerBody.gravityScale *= -1;
        }
    }

    public void Cooldown() {}
}
