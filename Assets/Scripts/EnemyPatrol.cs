using UnityEngine;

public class EnemyPatrol : MonoBehaviour, IDamageable
{
    public Vector2 patrolPoint1;
    public Vector2 patrolPoint2;
    public float patrolSpeed = 2.0f;
    private Animator animator;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    private bool movingToPoint1 = true;
    public int Health = 1;
    public GameObject powerOrb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        
    }

    private void Update()
    {
        if (movingToPoint1)
        {
            MoveTo(patrolPoint1);
            if ((Vector2)transform.position == patrolPoint1)
                movingToPoint1 = false;
        }
        else
        {
            MoveTo(patrolPoint2);
            if ((Vector2)transform.position == patrolPoint2)
                movingToPoint1 = true;
        }
    }

    private void MoveTo(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, patrolSpeed * Time.deltaTime);

        // Check the direction of movement and flip sprite accordingly
        if (target.x > transform.position.x)
            spriteRenderer.flipX = false; // Moving right
        else if (target.x < transform.position.x)
            spriteRenderer.flipX = true; // Moving left
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the attack animation
            animator.SetTrigger("Attack");
        }
    }

    public void OnHit(int damage)
    {
        if(Health > 0)
        {
            Health--;


        }
        if (Health <= 0)
        {
            OnDeath();
        }


        Debug.Log("hit enemy");
    }

    public void OnDeath()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("Death");
    }

    public void DestroySelf()
    {
       GameObject power = Instantiate(powerOrb,transform.position,transform.rotation);
        Rigidbody2D powerRigidbody = power.GetComponent<Rigidbody2D>();

        // Apply a force to make the powerOrb blast away
        if (powerRigidbody != null)
        {
            // You may need to adjust the force values based on your game's requirements
            Vector2 blastDirection = new Vector2(1f, 1f); // Adjust direction as needed
            powerRigidbody.AddForce(blastDirection.normalized * 5f, ForceMode2D.Impulse);
        }
        Destroy(gameObject);
    }
}
