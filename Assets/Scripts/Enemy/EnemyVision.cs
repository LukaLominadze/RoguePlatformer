using UnityEngine;


public class EnemyVision : MonoBehaviour
{
    // Enum data for determening what kind of FOV the enemy will have
    enum VisionType { line, circle };

    [SerializeField] EventHandler EHandler;

    [SerializeField] LayerMask playerLayer;

    [Header("Linecast")]
    [SerializeField] private float linecastLenght;
    [Space(10)]

    [Header("Circlecast")]
    [SerializeField] private float radius;
    [Space(10)]

    [SerializeField] private Vector2 offset;
    [Space(10)]

    [SerializeField] VisionType cast = VisionType.line;

    private bool canSeePlayer;

    private Vector2 linecastEnd;

    public bool DetectPlayer()
    {
        switch (cast)
        {
            case VisionType.line:
                return Linecast();
            case VisionType.circle:
                return Circlecast();
        }
        return false;
    }

    private bool Linecast()
    {
        linecastEnd = (Vector2)transform.position + Vector2.right * linecastLenght * transform.localScale.x;

        canSeePlayer = Physics2D.Linecast(transform.position, linecastEnd, playerLayer);

        return canSeePlayer;
    }

    private bool Circlecast()
    {
        canSeePlayer = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(transform.localScale.x * offset.x, offset.y),
                                                radius, playerLayer);

        return canSeePlayer;
    }

    public void OnDetect(int nextEvent)
    {
        if (DetectPlayer())
        {
            EHandler.SetEvent((Events)nextEvent);
        }
    }


    public void OnDetectFailed(int nextEvent)
    {
        if (!DetectPlayer())
        {
            EHandler.SetEvent((Events)nextEvent);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * linecastLenght * transform.localScale.x);

        Gizmos.DrawWireSphere((Vector2)transform.position + new Vector2(transform.localScale.x * offset.x, offset.y),
                               radius);
    }
}
