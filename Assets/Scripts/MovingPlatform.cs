using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float speed = 1.0f;

    private bool movingUp = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        // Move the platform up and down between startPosition and endPosition
        if (movingUp)
        {
            if ((Vector2)transform.position == endPosition)
                movingUp = false;
            else
                MovePlatform(endPosition);
        }
        else
        {
            if ((Vector2)transform.position == startPosition)
                movingUp = true;
            else
                MovePlatform(startPosition);
        }
    }

    private void MovePlatform(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
