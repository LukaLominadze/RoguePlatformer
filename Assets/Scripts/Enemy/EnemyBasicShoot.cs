using UnityEngine;

public class EnemyBasicShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [Space(10)]
    [SerializeField] Rigidbody2D rb;
    [Space(10)]
    [SerializeField] EventHandler EHandler;
    [SerializeField] EnemyVision enemyVision;
    [Space(15)]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float recoilTime;
    [SerializeField] private float damage;
    [SerializeField] private float knockback;
    [SerializeField] private string targetTag;
    [SerializeField] Events nextEvent;
    [Space(10)]
    [SerializeField] private bool stopEnemy = false;

    private float elapsedTime = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EHandler = GetComponent<EventHandler>();
        enemyVision = GetComponent<EnemyVision>();
    }

    public void Shoot()
    {
        if (elapsedTime == 0)
        {
            if (stopEnemy)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            Attack bulletScript = bullet.GetComponent<Attack>();

            bulletScript.Init(targetTag, damage, knockback);

            bulletBody.AddForce(bulletSpawn.right * bulletSpeed, ForceMode2D.Impulse);

            elapsedTime += Time.fixedDeltaTime;
        }
        else
        {
            elapsedTime += Time.fixedDeltaTime;

            if (elapsedTime >= recoilTime)
            {
                elapsedTime = 0;
            }
        }
        if (!enemyVision.DetectPlayer())
        {
            EHandler.SetEvent(nextEvent);
        }
    }

    private void FixedUpdate()
    {
        if (elapsedTime != 0)
        {
            elapsedTime += Time.fixedDeltaTime;
            if (elapsedTime >= recoilTime)
            {
                elapsedTime = 0;
            }
        }
    }
}
