using UnityEngine;

public class Player : MonoBehaviour
{
    Gun[] guns;
    Rigidbody2D rb;

    float moveSpeed = 5;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool speedDown;
    bool shoot;

    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        rb = GetComponent<Rigidbody2D>(); // importante
    }

    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.DownArrow);
        moveLeft = Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.RightArrow);
        speedDown = Input.GetKey(KeyCode.LeftShift);
        shoot = Input.GetKeyDown(KeyCode.Z);

        if (shoot)
        {
            shoot = false;
            foreach (Gun gun in guns)
            {
                if (gun.gameObject.activeSelf)
                {
                    gun.Shoot();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = rb.position; // usamos Rigidbody

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        if (speedDown)
        {
            moveAmount /= 1.5f;
        }

        Vector2 move = Vector2.zero;

        if (moveUp) move.y += moveAmount;
        if (moveDown) move.y -= moveAmount;
        if (moveLeft) move.x -= moveAmount;
        if (moveRight) move.x += moveAmount;

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move;

        rb.MovePosition(pos); // movimiento correcto
    }
}