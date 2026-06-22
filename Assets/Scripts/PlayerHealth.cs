using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    bool isDead = false;

    PlayerSprite playerSprite;

    void Start()
    {
        playerSprite = GetComponentInChildren<PlayerSprite>();
        playerSprite.UpdateSprite(health);

        HUDManager.instance.UpdateLives(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        playerSprite.UpdateSprite(health);

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