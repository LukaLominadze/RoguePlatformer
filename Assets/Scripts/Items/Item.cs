using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] UnityEvent m_event;

    const string PLAYER = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If a player tries to pick up the item, run the specified scripts in "m_event"
        if (collision.CompareTag(PLAYER))
        {
            m_event?.Invoke();
        }
    }
}
