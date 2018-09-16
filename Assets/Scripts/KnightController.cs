using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour {

    public LayerMask BlockingLayer;

    // Normal Movements Variables
    private BoxCollider2D boxCollider;
    private float walkSpeed;
    private float sprintSpeed;
    private float curSpeed;
    private float maxSpeed;
    private Rigidbody2D rb2d;
    private Vector3 move = Vector3.zero;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private CharacterStat plStat;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        plStat = GetComponent<CharacterStat>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager.HP = 100;

        walkSpeed = (float)(plStat.Speed + (plStat.Agility / 5));
        sprintSpeed = walkSpeed + (walkSpeed / 2);
    }

    void Update()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;
        move = transform.position;

        // Move senteces
        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("knightAttack");
        }

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("knightBlock");
        }
        else if (Input.GetMouseButtonUp(1))
        {
            anim.SetTrigger("knightUnBlock");
        }

        if (Input.GetButton("Horizontal"))
        {
            move.x += Input.GetAxis("Horizontal") * 0.1f;
            rb2d.AddForce(Vector2.right * curSpeed);
            transform.position = move;
        }

        if (Input.GetButtonDown("Horizontal") || Input.GetButton("Horizontal"))
        {
            Vector3 charDir = Vector3.zero;
            charDir.x = Input.GetAxis("Horizontal");
            if (charDir.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }

        if (Input.GetButton("Vertical"))
        {
            move.y += Input.GetAxis("Vertical") * 0.1f;
            rb2d.AddForce(Vector2.up * curSpeed);
            transform.position = move;
        }

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            anim.SetTrigger("knightWalk");
        }

        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            anim.SetTrigger("knightStop");
        }

        if (GameManager.HP == 0)
        {
            anim.SetTrigger("knightDie");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}