using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public InputAction MoveAction;
    Rigidbody2D rb2d;
    Vector2 move;
    
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
        MoveAction.Enable();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if (Keyboard.current.upArrowKey.isPressed)

        move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rb2d.position
                             + move * MoveSpeed * Time.deltaTime;
        rb2d.MovePosition(position);
    }
}
