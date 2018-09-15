using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7f;
    public float jumpForce = 1000f;
    public Rigidbody2D projectile;
    Vector3 moves = Vector3.zero;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
 
    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            moves = transform.position;
            moves.y += 1f;
            animator.SetTrigger("knightJump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            transform.position = moves;
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("knightAttack");
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("knightBlock");
        }

        if (Input.GetMouseButtonUp(1))
        {
            animator.SetTrigger("knightUnBlock");
        }

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            animator.SetTrigger("knightWalk");
        }

        if (Input.GetButtonDown("Fire3"))
        {
            animator.SetTrigger("knightCast");
        }

        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            moves = transform.position;
            moves.x -= .01f;
            transform.position = moves;
        }

        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            moves = transform.position;
            moves.x += .01f;
            transform.position = moves;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moves = transform.position;
            moves.z += .01f;
            transform.position = moves;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moves = transform.position;
            moves.z -= .01f;
            transform.position = moves;
        }

        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            animator.SetTrigger("knightStop");
        }
        
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x += Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}
