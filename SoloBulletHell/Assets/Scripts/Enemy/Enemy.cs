using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public int CurrentHealth = 2;
    public int MaxHealth = 2 ;
    public float Speed;

    public int DamageDealt = 2;

    void Start()
    {
        MaxHealth = CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0)
        {
            //Enemy Death animation
            StartCoroutine("DelayDestroyEnemy");
        }
    }

    public void Damage(int amount)
    {
        CurrentHealth -= amount;
    }

    IEnumerator DelayDestroyEnemy()
    {
        //Enemy Death animation goes here
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<AIPath>().canMove = false;
        yield return new WaitForSeconds(2f);
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (collision.gameObject.GetComponent<Player>().CanBeHit)
            {
                collision.gameObject.GetComponent<Player>().Damage(DamageDealt);
            }
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (collision.gameObject.GetComponent<Player>().CanBeHit)
            {
                collision.gameObject.GetComponent<Player>().Damage(DamageDealt);
            }
        }
    }

    public void SetMaxHealth()
    {
        MaxHealth = 2 * Mathf.RoundToInt(LevelManager.Level / 2);
        CurrentHealth = MaxHealth;
        if (MaxHealth == 0)
        {
            MaxHealth = 2;
            CurrentHealth = 2;
        }

    }

}
