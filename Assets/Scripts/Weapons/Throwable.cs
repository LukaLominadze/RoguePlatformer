using UnityEngine;

public class Throwable : MonoBehaviour
{
    [SerializeField] private float weaponSpeed;

    void FixedUpdate()
    {
        transform.Translate((transform.right * transform.localScale.x * weaponSpeed) * Time.fixedDeltaTime);
    }
}
