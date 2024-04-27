#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ConvertWeaponToItem : MonoBehaviour
{
    [MenuItem("Prefab Creator/Item/Weapon")]
    public static void ConvertToItem()
    {
        //Load the prefab path
        string prefabPath = "Assets/Prefabs/Items/Weapons/ItemWeaponBase Variant.prefab";
        // Load the base weapon item prefab from Resources (assuming it's in a folder called "Prefabs")
        GameObject itemWeaponPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

        if (itemWeaponPrefab != null)
        {
            // Get the currently selected object in the Hierarchy
            GameObject selectedObject = Selection.activeGameObject;

            if (selectedObject != null)
            {
                // Instantiate an instance of the base weapon item prefab
                GameObject newItemWeapon = Instantiate(itemWeaponPrefab);
                // Make sure this new instance's nae is not the same as the selected object in the hierarchy
                newItemWeapon.name = itemWeaponPrefab.name + "_Instance";

                //Add the appropriate tag for the new item
                newItemWeapon.tag = selectedObject.tag;

                // Get the "ItemWeapon" script attached to the instantiated object
                ItemWeapon itemScript = newItemWeapon.GetComponent<ItemWeapon>();
                if (itemScript != null)
                {
                    // Set the instantiated object's sprite to match the selected object's sprite
                    SpriteRenderer spriteRenderer = newItemWeapon.GetComponent<SpriteRenderer>();
                    Sprite selectedSprite = selectedObject.GetComponent<SpriteRenderer>()?.sprite;
                    if (spriteRenderer != null && selectedSprite != null)
                    {
                        spriteRenderer.sprite = selectedSprite;
                    }

                    // Assign the selected object's base prefab to the "ItemWeapon"'s ItemPrefab variable
                    itemScript.SetItemPrefab(FindPrefabForInstance(selectedObject));

                    // Save the modified instance as a new prefab variant
                    string newPrefabPath = $"Assets/Resources/Prefabs/Items/Weapons/Item{selectedObject.name}.prefab";
                    GameObject newPrefabVariant = PrefabUtility.SaveAsPrefabAsset(newItemWeapon, newPrefabPath);
                    Selection.activeObject = newPrefabVariant;

                    Debug.Log("New prefab variant created: " + prefabPath);
                }
                else
                {
                    Debug.LogWarning("The instantiated object doesn't have an 'Item' script attached.");
                }

                DestroyImmediate(newItemWeapon);
            }
            else
            {
                Debug.LogWarning("Please select a GameObject to convert into an item.");
            }
        }
        else
        {
            Debug.LogWarning($"ItemWeapon prefab not found in {prefabPath} folder.");
        }
    }

    private static GameObject FindPrefabForInstance(GameObject instance)
    {
        string folderPath = "Assets/Prefabs/Weapons";
        string prefabName = instance.name;
        return AssetDatabase.LoadAssetAtPath<GameObject>($"{folderPath}/{prefabName}.prefab");
    }
}
#endif
