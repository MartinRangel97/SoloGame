using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class FireWeapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletProjectile;

    [Header("Weapon Modifiers")]
    private float WeaponSpeed = 20f;

    private bool AbleToFire = true;
    private bool IsFiring = false;

    [SerializeField] private InputActionReference actionReference;

    private void OnEnable()
    {
        actionReference.action.Enable();
    }

    private void OnDisable()
    {
        actionReference.action.Disable();
    }

    private void Start()
    {
        actionReference.action.performed += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                IsFiring = true;
            }

        };

        actionReference.action.canceled += context =>
        {
            if (context.interaction is HoldInteraction)
            {
                IsFiring = false;
            }
        };
    }

    private void FixedUpdate()
    {
        if (IsFiring && AbleToFire)
        {
            GameObject Bullet = Instantiate(BulletProjectile, FirePoint.position, FirePoint.rotation);
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(FirePoint.up * WeaponSpeed, ForceMode2D.Impulse);
            AbleToFire = false;
            Invoke(nameof(CooldownFinished), gameObject.GetComponent<Player>().FireRate);
        }
    }

    private void CooldownFinished()
    {
        AbleToFire = true;
    }
}
