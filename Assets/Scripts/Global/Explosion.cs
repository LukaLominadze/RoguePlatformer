using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float explosionForce;
    [SerializeField] private float damage;

    [SerializeField] private float timeBeforeExplosion;

    [SerializeField] private bool destroyOnExplode;

    private float elapsedTime = 0;

    private void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;

        if (elapsedTime > timeBeforeExplosion)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D collider in colliders)
        {
            if (collider.name == name)
            {
                continue;
            }
            else if (collider.TryGetComponent(out Rigidbody2D body))
            {
                Vector2 distances = (collider.transform.position - transform.position);
                Vector2 direction = new Vector2(distances.x / radius, distances.y / radius);

                body.AddForce(direction * explosionForce, ForceMode2D.Impulse);

                if (collider.TryGetComponent(out HealthSystem health))
                {
                    collider.GetComponent<HealthSystem>().Damage(damage);
                }
            }
            else
            {
                continue;
            }
        }

        if (destroyOnExplode)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
