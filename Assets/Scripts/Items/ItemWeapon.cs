using UnityEngine;

public class ItemWeapon : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    
    private string weaponTag;

    private void Start()
    {
        weaponTag = gameObject.tag;
    }

    public void PickUp()
    {
        // Iterate through the weapon list
        for(int i = 0; i < WeaponSlots.Singleton.weapons.Count; i++)
        {
            // Match the iterated item's tag with the desired one
            if (WeaponSlots.Singleton.GetWeaponById(i).CompareTag(weaponTag))
            {
                // Instantiate new weapon in the player's weapon holder
                WeaponSlots.Singleton.SetNewWeapon(i, Instantiate(itemPrefab, WeaponSlots.Singleton.transform));

                // Destroy the item afterwards
                Destroy(gameObject);
            }
        }
    }

    public void SetItemPrefab(GameObject prefab)
    {
        itemPrefab = prefab;
    }
}
