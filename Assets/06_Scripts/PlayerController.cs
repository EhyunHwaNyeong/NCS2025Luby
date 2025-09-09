using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region CONST
    const int MIN_HEALTH = 0;
    const int MAX_HEALTH = 20;
    const int START_HEALTH = 5;
    const float MIN_SPEED = 1.0f;
    const float MAX_SPEED = 10.0f;
    const float START_SPEED = 5.0f;
    #endregion

    #region public
    public InputAction MoveAction;
    [Range(MIN_HEALTH, MAX_HEALTH)] public int maxHealth = START_HEALTH;
    [Range(MIN_SPEED, MAX_SPEED)] public float MoveSpeed = START_SPEED;
    public float timeInvincible = 2.0f;
    public float timeHeal = 2.0f;
    #endregion

    #region Property
    public int Health
    {
        get
        {
            return currentHealth;
        }
    }
    #endregion

    #region private
    int currentHealth;
    Rigidbody2D rb2d;
    Vector2 move;
    bool isInvincible;
    float damegeCooldown;
    bool isHealing;
    float HealCooldown;
    
    #endregion

    #region Method
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
        MoveAction.Enable();
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = 1; // maxHealth;
    }

    void Update()
    {
        // if (Keyboard.current.upArrowKey.isPressed)
        move = MoveAction.ReadValue<Vector2>();
        // Debug.Log(move);

        if (isInvincible)
        {
            damegeCooldown -= Time.deltaTime;
            if (damegeCooldown < 0)
            {
                isInvincible = false;
            }
        }
        if (isHealing)
        {
            HealCooldown -= Time.deltaTime;
            if (HealCooldown < 0)
            {
                isHealing = false;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rb2d.position
                             + move * MoveSpeed * Time.deltaTime;
        rb2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damegeCooldown = timeInvincible;
        }
        if (isHealing)
        {
            return;
        }
        else
        {
            isHealing = true;
            HealCooldown = timeHeal;
        }        

        currentHealth = Mathf.Clamp(currentHealth + amount, MIN_HEALTH, maxHealth);
        Debug.Log($"{currentHealth}/{maxHealth}");
    }
    #endregion
}
