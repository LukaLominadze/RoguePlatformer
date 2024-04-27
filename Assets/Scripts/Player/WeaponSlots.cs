using System.Collections.Generic;
using UnityEngine;

public class WeaponSlots : MonoBehaviour
{
    public static WeaponSlots Singleton;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
    }

    // Holds all the weapons
    [SerializeField] public List<GameObject> weapons = new List<GameObject>();

    [SerializeField] KeyCode input;

    private int currentSlot = 0;

    const string THROWABLE = "Throwable";

    private void Start()
    {
        // Get all the weapons
        Transform[] weaponArray = GetComponentsInChildren<Transform>();
        foreach (Transform weapon in weaponArray)
        {
            weapons.Add(weapon.gameObject);
        }

        // Delete the weaponslot singleton from the list
        weapons.RemoveAt(0);

        weaponArray = null;

        // Activate melee at start
        ChangeWeapon();
    }

    void Update()
    {
        if(Input.GetKeyDown(input))
        {
            // Cycle though the list
            currentSlot += 1;
            // Skip the next weapon if it is a throwable
            if (weapons[currentSlot].CompareTag(THROWABLE)) currentSlot += 1;
            // If index is out of range, reset iterator
            if (currentSlot == weapons.Count) currentSlot = 0;
            ChangeWeapon();
        }
    }

    private void ChangeWeapon()
    {
        // Deactivate all weapons
        foreach (GameObject weapon in weapons)
        {
            if (weapon.CompareTag(THROWABLE)) continue;
            weapon.SetActive(false);
        }

        // Activate only the desired weapon
        weapons[currentSlot].SetActive(true);
    }

    public void SetNewWeapon(int id, GameObject newWeapon)
    {
        // Destroy old weapon and replace with a new one
        Destroy(weapons[id]);
        weapons[id] = newWeapon;

        if (!weapons[id].CompareTag(THROWABLE))
        {
            currentSlot = id;
            ChangeWeapon();
        }
    }

    public GameObject GetWeaponById(int id)
    {
        return weapons[id];
    }

    public GameObject GetCurrentWeapon()
    {
        return weapons[currentSlot];
    }
}
