using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHit : MonoBehaviour
{
    private LifeManager lifeManager;

    private void Start()
    {
        lifeManager = FindObjectOfType<LifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            lifeManager.RemoveLife(10);
            Destroy(other.gameObject);
        }
    }
}
