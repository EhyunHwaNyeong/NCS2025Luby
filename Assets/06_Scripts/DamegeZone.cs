using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeZone : MonoBehaviour
{
    [SerializeField] int damegevalue;
    
    void OnTriggerStay2D(Collider2D collision)
    {
        // Debug.Log($"Trigger: {collision}");
        PlayerController controller =
            collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.ChangeHealth(damegevalue);
        }
    }
}
