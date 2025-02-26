using UnityEngine;

public class DecorMovement : MonoBehaviour
{
    public float speed = 1f; // Vertical speed

    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        // Calculate the movement down
        Vector3 movement = Vector3.down * speed * Time.deltaTime;

        // Apply the movement to the object's position
        transform.position += movement;
    }

    // Destroy the enemy when it collides with the KillZone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
        }
    }
}