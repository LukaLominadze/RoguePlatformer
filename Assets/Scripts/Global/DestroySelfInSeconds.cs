using UnityEngine;

public class DestroySelfInSeconds : MonoBehaviour
{
    [SerializeField] private float activeTime;

    private float elapsedTime = 0;

    void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;

        if (elapsedTime > activeTime)
        {
            Destroy(gameObject);
        }
    }
}
