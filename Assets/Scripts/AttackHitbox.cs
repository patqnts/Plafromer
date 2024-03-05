using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        Debug.Log(collision.gameObject.name);
        if (damageable != null)
        {

            damageable.OnHit(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        Debug.Log(collision.gameObject.name);
        if (damageable != null)
        {

            damageable.OnHit(1);
        }
    }
}
