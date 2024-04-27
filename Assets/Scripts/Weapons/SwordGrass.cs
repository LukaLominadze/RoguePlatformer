using UnityEngine;

public class SwordGrass : MonoBehaviour
{
    [SerializeField] GameObject grassPellet;

    [SerializeField] private string targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            Instantiate(grassPellet, transform.position, Quaternion.identity, null);
        }
    }
}
