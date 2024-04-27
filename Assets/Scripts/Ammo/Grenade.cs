using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float explosionForce;
    [SerializeField] private float damage;

    [SerializeField] private float timeBeforeExplosion;

    [SerializeField] private bool destroyOnExplode = false;

    private float elapsedTime = 0;

    private void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;

        if (elapsedTime > timeBeforeExplosion)
        {
            
        }
    }
}
