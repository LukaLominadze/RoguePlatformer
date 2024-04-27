using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [Header("Avoid Falling")]
    [SerializeField] Collision collision;
    [Space(10)]
    [Header("Stay in Boundaries")]
    [SerializeField] Transform leftBoundary;
    [SerializeField] Transform rightBoundary;
    [SerializeField] EnemyPatrol enemyPatrol;
    [Space(10)]
    [SerializeField] private bool turnAroundOnColl = true;

    const string ENEMYTAG = "Enemy";
    const string GROUND = "Ground";

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(leftBoundary != null && rightBoundary != null)
        {
            leftBoundary.SetParent(null);
            rightBoundary.SetParent(null);
        }
    }

    public void AvoidFalling()
    {
        if (!collision.OnGround(Mathf.Sign(transform.localScale.x)))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }
    }

    public void StayInBoundaries()
    {
        if (transform.position.x > rightBoundary.position.x || transform.position.x < leftBoundary.position.x)
        {
            enemyPatrol.ChangeDirection();

            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!turnAroundOnColl) return;
        if (collision.collider.CompareTag(GROUND) || collision.collider.CompareTag(ENEMYTAG))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }
    }
}
