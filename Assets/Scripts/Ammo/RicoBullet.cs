using UnityEngine;

public class RicoBullet : MonoBehaviour
{
    [SerializeField] private int maxRicochetCount;

    BoxCollider2D boxCollider;

    private int ricochetCount = 0;

    const string PLAYER = "Player";

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(boxCollider,
                                  GameObject.FindGameObjectWithTag(PLAYER).GetComponent<BoxCollider2D>());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ricochetCount++;

        if (ricochetCount > maxRicochetCount)
        {
            Destroy(gameObject);
        }
    }
}
