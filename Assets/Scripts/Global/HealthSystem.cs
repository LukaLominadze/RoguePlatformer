using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] private float health;

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Knockback(float knockback, Vector3 direction, float time)
    {
        if (rb == null) return;

        rb.velocity = Vector2.zero;
        StopCoroutine(KnockbackFeedback(0));

        rb.AddForce(direction * knockback, ForceMode2D.Impulse);

        StartCoroutine(KnockbackFeedback(time));
    }
    
    public void Heal(float amount)
    {
        health += amount;
    }

    private IEnumerator KnockbackFeedback(float time)
    {
        yield return new WaitForSeconds(time);

        rb.velocity = Vector2.zero;
    }

    public float GetHealth()
    {
        return health;
    }
}
