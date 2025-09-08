using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthColloectible : MonoBehaviour
{
    // public int healthvalue;
    [SerializeField] int healthvalue;
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log($"Trigger: {collision}");
        PlayerController controller =
            collision.GetComponent<PlayerController>();
        if ((controller != null) && (controller.maxHealth > controller.Health))
        {
            controller.ChangeHealth(healthvalue);
            Destroy(gameObject);
        }
    }
}
