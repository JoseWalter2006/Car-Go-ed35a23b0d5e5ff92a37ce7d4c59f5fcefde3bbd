using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    bool isDead = false;

    public void TakeDamage(int damage)
    {
        health -= damage;

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