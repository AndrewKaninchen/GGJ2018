using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public float maxHealth = 50f;
    private float currentHealth = 50f;
    public Score score;

    public GameObject damageAnimation;
    public GameObject deathEffect;

    public Action onDeath;

    private void Awake()
    {
        score = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<Score>();
    }

    private void Update()
    {
    }

    public void TakeDamage (float amount)
    {
        currentHealth -= amount;
        Debug.Log("DAMAGE!");

        if (currentHealth <= 0f)
        {
            Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject, 4);
            Die();
            score.Add(100);
        }

        else if (currentHealth <= 30)
        {
            damageAnimation.SetActive(true);
        }

        

    }

    void Die()
    {
        onDeath();
        //tem que consertar essa porra quando tiver mais tipo de bicho
        AIDirector.activeWalkers--;
        //Debug.Log(AIDirector.activeWalkers);
        Destroy(gameObject);
        
    }

}
