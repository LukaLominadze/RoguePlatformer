using UnityEngine;

public class RotateToObject : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform followObjectScale;

    [SerializeField] private float offset;

    private float angle;

    void Update()
    {
        SetAngle();
    }

    private void LateUpdate()
    {
        if (angle > -270 && angle < -90)
        {
            transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), 1);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), 1);
        }
    }

    private void SetAngle()
    {
        if (target == null)
        {
            return;
        }

        Vector2 lookDirection = transform.position - target.position;
        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - offset;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public Transform GetTarget()
    {
        return target;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;

        SetAngle();
    }
}
