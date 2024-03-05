using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, IDamageable
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float jumpCooldown = 1.5f;
    public Joystick joystick; // Reference to the Joystick
    public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    public HealthUIScript health;
    private bool canJump = true;
    private bool canMove = true;
    public int Health;
    public GameObject Restart;
    public int orbCollected = 0;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        orbCollected = 0;
    }

    private void Update()
    {
        if(canMove)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpButton();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }


        if (Health <= 0)
        {
            OnDeath();
        }
    }

    public void JumpButton()
    {
        if (canJump && canMove)
        {
            StartCoroutine(JumpCooldown());
        }
    }



    //private void Move()
    //{
    //    float moveInput = Input.GetAxis("Horizontal"); // Get the horizontal input from arrow keys

    //    rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    //    animator.SetFloat("Speed", Mathf.Abs(moveInput));

    //    // Check the direction of movement and flip sprite accordingly
    //    if (moveInput > 0)
    //    {
    //        spriteRenderer.flipX = false; // Moving right
    //    }
    //    else if (moveInput < 0)
    //    {
    //        spriteRenderer.flipX = true; // Moving left
    //    }
    //}
    private void Move()
    {
        float moveInput = joystick.Horizontal; // Get the horizontal input from the joystick

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Check the direction of movement and flip sprite accordingly
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // Moving right
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Moving left
        }
    }



    private IEnumerator JumpCooldown()
    {
        Jump();
        canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }

    private void Jump()
    {
        // Add a vertical force for the jump
        animator.SetTrigger("Jump");
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    public void Attack()
    {
        // Implement your attack logic here
        animator.SetTrigger("Attack");
    }

    public void OnHit(int damage)
    {
        if(Health > 0)
        {
            Health = Health - damage;
            health.DecreaseHealth(Health);
        }
        
    }

    public void OnDeath()
    {
        canMove = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        animator.SetTrigger("Death");
        Restart.SetActive(true);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
