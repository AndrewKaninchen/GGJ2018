﻿using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;

    public void TakeDamage (float amount)
    {
        health -= amount;
        Debug.Log("DAMAGE!");
        if (health <= 0f)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

}
