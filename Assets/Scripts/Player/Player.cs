using UnityEngine;

public class Player : MonoBehaviour
{
    private static GameObject player;

    private void Awake()
    {
        player = gameObject;
    }

    public static GameObject GetPlayer()
    {
        return player;
    }
}
