using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int Pierce;

    private void Start()
    {
        Pierce = Player.Pierce;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.name.Equals("Enemy(Clone)"))
    //    {
    //        collision.gameObject.GetComponent<Enemy>().Damage(Player.DamageDealt);
    //        if (Pierce == 1)
    //        {
    //            Destroy(gameObject);
    //        }
    //        else
    //        {
    //            Pierce--;
    //        }
    //    }

    //    if (collision.gameObject.name.Equals("Wall"))
    //    {
    //        //bounce
    //        Destroy(gameObject);
    //    }
        
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Enemy(Clone)"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(Player.DamageDealt);
            if (Pierce == 1)
            {
                Destroy(gameObject);
            }
            else
            {
                Pierce--;
            }
        }

        if (collision.gameObject.name.Equals("Wall"))
        {
            //bounce
            Destroy(gameObject);
        }
    }
}
