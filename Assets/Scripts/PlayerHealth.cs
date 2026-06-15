using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    bool isDead = false;

    void Start()
    {
        HUDManager.instance.UpdateLives(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        HUDManager.instance.UpdateLives(health);

        Debug.Log("Player HP: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;

        GameManager.instance.GameOver();

        Destroy(gameObject);
    }
}