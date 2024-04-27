using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] EventHandler EHandler;

    [SerializeField] EnemyVision enemyVision;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] private float posCheckInterval = 5;

    private Vector2 last_position;

    private float elapsedTime = 0;

    const string ENEMYTAG = "Enemy";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EHandler = GetComponent<EventHandler>();
        enemyVision = GetComponent<EnemyVision>();

        last_position = transform.position;
    }

    public void Move(float speed)
    {
        transform.position += (Vector3.right * transform.localScale.x * speed) * Time.fixedDeltaTime;

        if (enemyVision.DetectPlayer())
        {
            EHandler.SetEvent(Events.active);
        }

        elapsedTime += Time.fixedDeltaTime;
        
        if (elapsedTime > posCheckInterval)
        {
            if (Vector2.Distance(last_position, transform.position) < 0.01f)
            {
                ChangeDirection();
            }
            elapsedTime = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(ENEMYTAG))
        {
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
    }
}
