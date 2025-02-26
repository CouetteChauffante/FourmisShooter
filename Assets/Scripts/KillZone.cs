using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        // Destroy any enemy that enters the kill zone
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Kill: " + other.name);
            Destroy(other.gameObject);
        }
    }
}