using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Enemy"))
        {
            Debug.Log("Enemy Hit");
            collision.gameObject.GetComponent<Enemy>().Damage(Player.DamageDealt);
        }
        Destroy(gameObject);
    }
}
