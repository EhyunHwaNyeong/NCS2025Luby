using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    [SerializeField] int healthvalue;
    void OnTriggerStay2D(Collider2D collision)
    {
        // Debug.Log($"Trigger: {collision}");
        PlayerController controller =
            collision.GetComponent<PlayerController>();
        if ((controller != null) && (controller.maxHealth > controller.Health))
        {
            controller.ChangeHealth(healthvalue);

        }
    }
}
