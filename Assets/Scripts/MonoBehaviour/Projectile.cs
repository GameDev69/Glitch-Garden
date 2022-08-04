using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speedMoving = 1f;
    [SerializeField] private float speedRotation = 1f;
    [SerializeField] private float damage = 50f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speedMoving, Space.World);
        transform.Rotate(0, 0, -180 * speedRotation * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();

        if (attacker & health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
