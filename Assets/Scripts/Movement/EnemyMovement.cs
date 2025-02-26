using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyType { Fourmi, FoutrmiGrosse, FoutrmiRougre }
    public EnemyType enemyType;

    public float speed = 2f; // Vertical speed
    public float zigzagSpeed = 2f; // Only for FoutrmiRougre
    public float zigzagWidth = 2f; // Only for FoutrmiRougre

    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        Vector3 movement = Vector3.down * speed * Time.deltaTime;

        if (enemyType == EnemyType.FoutrmiRougre)
        {
            float xOffset = Mathf.Sin(Time.time * zigzagSpeed) * zigzagWidth;
            transform.position = new Vector3(startX + xOffset, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position += movement;
        }
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