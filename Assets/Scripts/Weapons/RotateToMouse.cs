using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField] Transform player;

    private Camera mainCamera;

    private float angle;

    const string PLAYER = "Player";

    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindWithTag(PLAYER).transform;
    }

    void FixedUpdate()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = (Vector2)transform.position - mousePosition;
        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 180;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void LateUpdate()
    {
        if (angle > -270 && angle < -90)
        {
            transform.localScale = new Vector3(player.localScale.x, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(player.localScale.x, 1, 1);
        }
    }
}
