using UnityEngine;

public class CloneWeapon : MonoBehaviour, IGlobalEvents
{
    [SerializeField] EventHandler eventHandler;

    public EventHandler EHandler => eventHandler;

    private GameObject currentWeapon;

    public void Ready()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentWeapon = Instantiate(WeaponSlots.Singleton.GetCurrentWeapon());
            EHandler.SetEvent(Events.active);
        }
    }

    public void Active()
    {
        
    }

    public void Cooldown()
    {
        Destroy(currentWeapon);
        currentWeapon = null;
    }
}
