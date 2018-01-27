﻿using UnityEngine;

public class HealthManager : MonoBehaviour {

    public float health = 50f;
    public Score score;

    public GameObject damageAnimation;
    public GameObject deathEffect;

    private void Awake()
    {
        score = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<Score>();
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        Debug.Log("DAMAGE!");

        if (health <= 30)
        {
            damageAnimation.SetActive(true);
        }

        if (health <= 0f)
        {  
            Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject, 4);
            Die();
            score.Add(100);
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

}
