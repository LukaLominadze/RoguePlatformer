using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public static AbilityHolder Singleton;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
    }

    public void SetAbility(Transform ability)
    {
        // Destroy current ability and replace with a new one
        Destroy(GetComponentInChildren<Transform>().gameObject);
        ability.SetParent(transform);
    }
}
