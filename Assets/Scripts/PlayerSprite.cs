using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public Sprite vida3;
    public Sprite vida2;
    public Sprite vida1;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void UpdateSprite(int health)
    {
        if (health >= 3)
        {
            sr.sprite = vida3;
        }
        else if (health == 2)
        {
            sr.sprite = vida2;
        }
        else if (health == 1)
        {
            sr.sprite = vida1;
        }
    }
}