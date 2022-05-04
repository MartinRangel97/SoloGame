using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int Pierce;
    private int Bounce;
    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    private void Start()
    {
        Pierce = Player.Pierce;
        Bounce = Player.Bounce;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
    }

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Wall"))
        {
            if (Bounce == 1)
            {
                Destroy(gameObject);
            }
            else
            {
                var speed = lastVelocity.magnitude;
                var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
                Debug.Log("Bounce" + speed.ToString() + " " + direction.ToString());
                rb.velocity = direction * Mathf.Max(speed, 20f);
                Bounce--;
            }
        }
    }
}
