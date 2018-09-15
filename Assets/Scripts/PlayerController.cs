using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7f;
    public float jumpForce = 1000f;
    public Rigidbody2D projectile;

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
            animator.SetTrigger("knightJump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            rb2d.MovePosition(velocity);
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

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetButtonDown("Fire3"))
        {
            animator.SetTrigger("knightCast");
            Rigidbody2D clone;

            clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
            clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        }
        
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

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

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}
