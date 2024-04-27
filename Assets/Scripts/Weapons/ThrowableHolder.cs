using UnityEngine;

public class ThrowableHolder : MonoBehaviour, IGlobalEvents
{
    [SerializeField] EventHandler eventHandler;
    [SerializeField] GameObject throwablePrefab;

    public EventHandler EHandler => eventHandler;

    const string PLAYER = "Player";

    private void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag(PLAYER).GetComponent<Transform>();

        transform.localScale = Vector3.one;
    }

    public void Ready()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GameObject throwable = Instantiate(throwablePrefab, transform.position, transform.rotation, null);
            throwable.transform.localScale = new Vector3(transform.lossyScale.x, 1, 1);
            EHandler.SetEvent(Events.cooldown);
        }
    }

    public void Active() {}

    public void Cooldown() {}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER)) return;
    }
}
