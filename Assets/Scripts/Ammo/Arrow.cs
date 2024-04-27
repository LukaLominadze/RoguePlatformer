using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] DestroySelfInSeconds arrowDestroyer;
    [SerializeField] Attack attackScript;

    [HideInInspector] public float offset;

    private float startPosY;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        arrowDestroyer = GetComponent<DestroySelfInSeconds>();
        attackScript = GetComponent<Attack>();

        startPosY = transform.localPosition.y;
    }

    private void Update()
    {
        if (transform.parent != null) AnimateArrow();
    }

    private void FixedUpdate()
    {
        if (transform.parent != null) return;

        transform.localRotation = Quaternion.Euler(0, 0, Mathf.Atan2(_rigidbody.velocity.y, _rigidbody.velocity.x) * Mathf.Rad2Deg);
    }

    private void AnimateArrow()
    {
        transform.localPosition = new Vector2(offset, startPosY);
    }

    public void ShootArrow(float force, float damage, float knockback, string targetTag)
    {
        _rigidbody.AddForce(transform.right * force, ForceMode2D.Impulse);
        _rigidbody.gravityScale = 1;

        animator.enabled = false;

        transform.SetParent(null);

        boxCollider.enabled = true;

        attackScript.Init(targetTag, damage, knockback);

        if (arrowDestroyer.enabled == false)
        {
            arrowDestroyer.enabled = true;
        }
    }
}
