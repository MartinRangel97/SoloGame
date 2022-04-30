using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int CurrentHealth = 8;
    public int MaxHealth = 8 ;
    public float Speed;

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
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(2f);
        Debug.Log("Enemy Dead");
        Destroy(gameObject);
    }


}
