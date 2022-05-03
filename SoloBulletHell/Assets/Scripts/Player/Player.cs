using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    public float moveSpeed;
    public int CurrentHealth;
    public int MaxHealth;
    public int HealingFactor;
    public static int DamageDealt;
    public float InvulnerabilityBuffer;
    public float FireRate;
    public int Pierce;
    public int Bounce;

    [Header("UI")]
    public HealthBar healthBar;

    public bool CanBeHit = true;
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
        if (moveInput.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveInput.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void Damage(int amount)
    {
        CurrentHealth -= amount;
        healthBar.SetCurrentHealth();
        CanBeHit = false;
        StartCoroutine("InvulnerabilityState");
        if (CurrentHealth <= 0)
        {
            //Game Over
        }
    }

    private IEnumerator InvulnerabilityState()
    {
        yield return new WaitForSeconds(InvulnerabilityBuffer);
        CanBeHit = true;
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

    public void AddPowerup(string name)
    {
        switch (name)
        {
            case "Pierce":
                Pierce += int.Parse(Powerups.FindPowerup(name).value.ToString());
                break;
            case "Bounce":
                Bounce += int.Parse(Powerups.FindPowerup(name).value.ToString());
                break;
            case "Damage":
                DamageDealt += int.Parse(Powerups.FindPowerup(name).value.ToString());
                break;
            case "Fire Rate":
                FireRate = (1 - Powerups.FindPowerup(name).value) * FireRate;
                break;
            case "Health":
                MaxHealth += int.Parse(Powerups.FindPowerup(name).value.ToString());
                break;
            case "Speed":
                moveSpeed += Powerups.FindPowerup(name).value;
                break;
        }
    }

    public void SetBasicStats()
    {
        moveSpeed = 5f;
        CurrentHealth = 8;
        MaxHealth = 8;
        HealingFactor = 1;
        DamageDealt = 2;
        InvulnerabilityBuffer = 1f;
        FireRate = 0.1f;
        Pierce = 1;
        Bounce = 1;
    }
}
