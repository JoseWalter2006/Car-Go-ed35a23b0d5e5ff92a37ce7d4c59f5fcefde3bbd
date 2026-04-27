using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 6f;
    public float verticalSpeed = 2f;
    public float leftLimit = -8.1f;
    public float rightLimit = 4f;
    public float stopY = 3.71f;

    int direction = 1;

    [Header("Activación")]
    public float activationY = 5f; // cuando se vuelve "activo"
    bool isActive = false;

    [Header("Vida")]
    public int health = 3;

    [Header("Disparo")]
    public GameObject bulletPrefab;
    public float fireRate = 1.5f;
    float nextFireTime;

    void Update()
    {
        Move();

        // Se activa cuando entra en pantalla
        if (!isActive && transform.position.y <= activationY)
        {
            isActive = true;
        }

        // Solo ataca si ya está activo
        if (isActive)
        {
            Attack();
        }

        // limpieza
        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        // Movimiento horizontal
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Movimiento hacia abajo hasta stopY
        if (transform.position.y > stopY)
        {
            transform.Translate(Vector2.down * verticalSpeed * Time.deltaTime);

            if (transform.position.y < stopY)
            {
                transform.position = new Vector2(transform.position.x, stopY);
            }
        }

        // Rebote
        if (transform.position.x >= rightLimit)
        {
            direction = -1;
            transform.position = new Vector2(rightLimit, transform.position.y);
        }

        if (transform.position.x <= leftLimit)
        {
            direction = 1;
            transform.position = new Vector2(leftLimit, transform.position.y);
        }
    }

    void Attack()
    {
        if (bulletPrefab == null) return;

        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        Vector3 spawnPos = new Vector3(
            transform.position.x,
            sr.bounds.min.y,
            transform.position.z
        );

        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        Bullet b = bullet.GetComponent<Bullet>();

        if (b != null)
        {
            b.direction = Vector2.down;
            b.isEnemy = true;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isActive) return; // NO recibe daño si aún no es visible

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}