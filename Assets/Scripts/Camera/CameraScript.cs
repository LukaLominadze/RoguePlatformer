using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] private Vector2 cameraSize;
    [SerializeField] private float leftBoundary;
    [SerializeField] private float rightBoundary;
    [SerializeField] private float topBoundary;
    [SerializeField] private float bottomBoundary;

    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBoundary, rightBoundary),
                                         Mathf.Clamp(transform.position.y, bottomBoundary, topBoundary), -10);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(new Vector2((leftBoundary + rightBoundary) / 2, (bottomBoundary + topBoundary) / 2),
            new Vector2(Vector2.Distance(Vector2.right * (leftBoundary - cameraSize.x/2), Vector2.right * (rightBoundary + cameraSize.x / 2)),
                        Vector2.Distance(Vector2.right * (bottomBoundary - cameraSize.y / 2), Vector2.right * (topBoundary + cameraSize.y / 2))));
    }
}
