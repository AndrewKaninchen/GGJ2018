using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;

    public Score score;

    private void Awake()
    {
        score = GameObject.FindGameObjectsWithTag("Score")[0].GetComponent<Score>();
    }

    public void TakeDamage (float amount)
    {
        health -= amount;
        Debug.Log("DAMAGE!");
        if (health <= 0f)
        {
            Die();
            score.Add(100);
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

}
