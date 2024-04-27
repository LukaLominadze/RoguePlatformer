using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] private Vector2 boxCastSize;
    [SerializeField] private Vector2 offset;

    // Indicate how far the boxCast's origin is from the player's origin
    [SerializeField] private float boxCastDistance;

    private bool onGround;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //direction exists for offsetted boxcasts
    public bool OnGround(float direction=1)
    {
        onGround = Physics2D.BoxCast((Vector2)boxCollider.bounds.center + offset * direction, boxCastSize, 0, Vector2.down, boxCastDistance,
                                     groundLayer);

        return onGround;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireCube(boxCollider.bounds.center + Vector3.down * boxCastDistance + 
                            new Vector3(transform.localScale.x * offset.x, offset.y, 1), boxCastSize);
    }
}
