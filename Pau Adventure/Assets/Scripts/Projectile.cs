﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D projectileRB2D;


    private void Awake()
    {
        projectileRB2D = GetComponent<Rigidbody2D>();
    }

   

    private void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch (Vector2 direction, float force)
    {
        projectileRB2D.AddForce(direction * force);
    
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Projecile Collision with " + other.gameObject);
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.FixedUpdate();
        }
        Destroy(gameObject);
    }
}

