using UnityEngine;

[RequireComponent(typeof(RotateToObject))]
public class EnemeyRotateToPlayer : MonoBehaviour
{
    RotateToObject rotationScript;

    void Start()
    {
        rotationScript = GetComponent<RotateToObject>();
    }

    public void SetTarget(bool value)
    {
        if (value && rotationScript.GetTarget() == null)
        {
            rotationScript.SetTarget(Player.GetPlayer().transform);
        }
        else if (value && rotationScript.GetTarget() != null)
        {
            return;
        }
        else
        {
            rotationScript.SetTarget(null);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
