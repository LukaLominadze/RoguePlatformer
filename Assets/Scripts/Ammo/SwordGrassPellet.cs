using UnityEngine;

public class SwordGrassPellet : MonoBehaviour
{
    [SerializeField] private float radius;

    [SerializeField] private float lerpTime;

    private Vector2 startPos;
    private Vector2[] randomDestinations = new Vector2[3];

    private int currentDestination = 0;

    private void Start()
    {
        startPos = transform.position;
        Vector2 borderX = new Vector2(startPos.x - radius, startPos.x + radius);
        Vector2 borderY = new Vector2(startPos.y - radius, startPos.y + radius);

        for (int i = 0; i < randomDestinations.Length; i++)
        {
            randomDestinations[i] = new Vector2(Random.Range(borderX.x, borderX.y),
                                                Random.Range(borderY.x, borderY.y));
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, randomDestinations[currentDestination],
                                          lerpTime * Time.fixedDeltaTime);
        if (Vector2.Distance(transform.position, randomDestinations[currentDestination]) < 0.1f)
        {
            currentDestination += 1;
        }

        if (currentDestination == randomDestinations.Length)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(startPos, radius);
    }
}
