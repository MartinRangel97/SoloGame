using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed = 5f;
    public int CurrentHealth = 8;
    public int MaxHealth = 8;
    public int HealingFactor = 1;


    [Header("UI")]
    public HealthBar healthBar;

    private Vector2 moveInput;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void FixedUpdate()
    {
        Vector2 targetMovePosition = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetMovePosition);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void Damage(int amount)
    {
        CurrentHealth -= amount;
        healthBar.SetCurrentHealth();
        
        if (CurrentHealth <= 0)
        {
            //Game Over
        }
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount * HealingFactor;
        healthBar.SetCurrentHealth();

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
}
