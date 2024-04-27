using UnityEngine;

public class GunScript : MonoBehaviour, IGlobalEvents
{
    [SerializeField] EventHandler eventHandler;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;
    [SerializeField] Animator animator;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float knockback;

    [SerializeField] private string idleAnim;
    [SerializeField] private string attackAnim;
    [SerializeField] private string targetTag;

    private bool input;

    public EventHandler EHandler => eventHandler;

    void Update()
    {
        input = Input.GetKey(KeyCode.Mouse0);
    }

    public void Ready()
    {
        if (input)
        {
            animator.Play(attackAnim);

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, transform.rotation);
            Attack bulletScript = bullet.GetComponent<Attack>();
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();

            bulletScript.Init(targetTag, damage, knockback);
            bulletBody.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);

            EHandler.SetEvent(Events.active);
        }
    }

    public void Active()
    {
    }

    public void Cooldown()
    {
        animator.Play(idleAnim);
    }
}
