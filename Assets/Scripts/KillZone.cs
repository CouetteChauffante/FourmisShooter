using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Decor"))
        {
            Debug.Log("Kill: " + other.name);
            Destroy(other.gameObject);
        }
    }
}