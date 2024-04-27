using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    private enum DirectionType { scale, rotation }

    private HealthSystem healthSys;

    [SerializeField] private float damage;
    [SerializeField] private float knockback = 0;
    [SerializeField] private float knockTime = 0.2f;

    [SerializeField] private string targetTag;

    [SerializeField] DirectionType directionType;

    [SerializeField] UnityEvent onAttack;

    // This function exists for objects that will be instantiated
    // To ensure we can tinker only with the values of prefabs without creating new variants of it
    // It strictly exists to be called from a different instance than this one
    public void Init(string targetTag, float damage, float knockback=0)
    {
        this.targetTag = targetTag;
        this.damage = damage;
        this.knockback = knockback;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            healthSys = collision.gameObject.GetComponent<HealthSystem>();

            onAttack?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(targetTag))
        {
            healthSys = collision.gameObject.GetComponent<HealthSystem>();

            onAttack?.Invoke();
        }
    }

    public void Knockback()
    {
        Vector3 direction = Vector3.zero;
        switch (directionType)
        {
            case DirectionType.scale:
                direction = Vector3.right * transform.lossyScale.x;
                break;
            case DirectionType.rotation:
                direction = transform.right;
                break;
        }
        healthSys.Knockback(knockback, direction, knockTime);
    }

    public void Damage()
    {
        healthSys.Damage(damage);
    }
}