﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public AudioClip hurt;

    private Transform target;
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target.position.x > transform.position.x)
            sprite.flipX = true;
        else
            sprite.flipX = false;
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetBool("Walking", true);
        }
        if (Health.currentHealth == 0)
        {
            enabled = false;
        }
        else
        {
            enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var hit = collision.gameObject;
        var audio = hit.GetComponent<AudioSource>();
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
            audio.clip = hurt;
            audio.Play();
        }

        hit.GetComponent<Experience>().GainExp(3);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
