using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public bool moveLeft = false;
    public bool moveRight = false;
    public bool moveUp = false;
    public bool moveDown = false;
    public float distance = 5f;
    public bool activate = false;
    public float speed = 1f;

    private Vector3 initialPosition;
    private bool movingRight = true;
    private bool movingUp = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (activate)
        {
            if (moveLeft && moveRight)
            {
                MoveHorizontal();
            }
            else if (moveLeft)
            {
                MoveLeftOnce();
            }
            else if (moveRight)
            {
                MoveRightOnce();
            }

            if (moveUp && moveDown)
            {
                MoveVertical();
            }
            else if (moveUp)
            {
                MoveUpOnce();
            }
            else if (moveDown)
            {
                MoveDownOnce();
            }
        }
    }

    void MoveHorizontal()
    {
        float moveDirection = movingRight ? 1 : -1;
        transform.Translate(Vector2.right * moveDirection * speed * Time.deltaTime);
        if (Vector2.Distance(initialPosition, transform.position) >= distance)
        {
            movingRight = !movingRight;
            initialPosition = transform.position;  // Reset initial position
        }
    }

    void MoveLeftOnce()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (Vector2.Distance(initialPosition, transform.position) >= distance)
        {
            activate = false;
        }
    }

    void MoveRightOnce()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Vector2.Distance(initialPosition, transform.position) >= distance)
        {
            activate = false;
        }
    }

    void MoveVertical()
    {
        float moveDirection = movingUp ? 1 : -1;
        transform.Translate(Vector2.up * moveDirection * speed * Time.deltaTime);
        if (Vector2.Distance(initialPosition, transform.position) >= distance)
        {
            movingUp = !movingUp;
            initialPosition = transform.position;  // Reset initial position
        }
    }

    void MoveUpOnce()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (Vector2.Distance(initialPosition, transform.position) >= distance)
        {
            activate = false;
        }
    }

    void MoveDownOnce()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (Vector2.Distance(initialPosition, transform.position) >= distance)
        {
            activate = false;
        }
    }
}
