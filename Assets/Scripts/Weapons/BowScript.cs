using UnityEngine;

public class BowScript : MonoBehaviour, IGlobalEvents
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] EventHandler eventHandler;

    [SerializeField] private float arrowSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float knockback;

    [SerializeField] private string targetTag;

    private float animationTime;
    private float elapsedTime = 0;

    private GameObject arrowHolder;
    private ArrowHolder arrowScript;

    public EventHandler EHandler => eventHandler;

    public void Ready()
    {
        // Listen for input
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Instantiate the arrow holder
            arrowHolder = Instantiate(arrowPrefab, transform.position, transform.rotation, transform);
            
            // Get the script of the instance
            arrowScript = arrowHolder.GetComponent<ArrowHolder>();
            // Get the arrow animation time
            animationTime = arrowScript.GetAnimationTime();

            EHandler.SetEvent(Events.active);
        }
    }

    public void Active()
    {
        // Get the elapsed time from the start of the arrow animations
        elapsedTime += Time.fixedDeltaTime;
        elapsedTime = Mathf.Clamp(elapsedTime, 0, animationTime);

        if (!Input.GetKey(KeyCode.Mouse0))
        {
            // Divide the elapsedTime by animationTime to ensure the longer the player pulls the arrow back,
            // The stronger it will be launched in the desired direction
            arrowScript.ShootArrows(arrowSpeed * (elapsedTime / animationTime), damage, knockback, targetTag);

            EHandler.SetEvent(Events.cooldown);
        }
    }

    public void Cooldown()
    {
        arrowHolder = null;
        elapsedTime = 0;
    }
}
