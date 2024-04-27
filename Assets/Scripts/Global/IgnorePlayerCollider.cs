using UnityEngine;

public class IgnorePlayerCollider : MonoBehaviour
{
    const string PLAYER = "Player";

    private BoxCollider2D thisCollider;
    private BoxCollider2D playerCollider;

    private void Awake()
    {
        thisCollider = GetComponent<BoxCollider2D>();
        playerCollider = GameObject.FindGameObjectWithTag(PLAYER).GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(thisCollider, playerCollider);
    }
}
