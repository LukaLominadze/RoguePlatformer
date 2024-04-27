using UnityEngine;

public class Wings : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    [SerializeField] PlayerJump jumpScript;

    [SerializeField] private float flyingSpeed;
    [SerializeField] private float minFallSpeed;
    [SerializeField] private float accelInSeconds;

    private bool flyInput;

    const string PLAYERTAG = "Player";

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag(PLAYERTAG);

        playerBody = player.GetComponent<Rigidbody2D>();
        jumpScript = player.GetComponent<PlayerJump>();
    }

    private void Update()
    {
        flyInput = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
        if (flyInput)
        {
            jumpScript.enabled = false;
            playerBody.velocity += new Vector2(0, flyingSpeed);
        }
        else
        {
            jumpScript.enabled = true;
            playerBody.mass = 1;
        }

        playerBody.velocity = new Vector2(playerBody.velocity.x,
                                              Mathf.Clamp(playerBody.velocity.y, minFallSpeed, flyingSpeed));
    }
}
