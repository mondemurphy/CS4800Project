﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExamplePlayerController : MonoBehaviour {

    public float flWalkingSpeed = 1.0f;
    public AudioClip swing;
    public static bool dungeon1 = false;
    public GameObject fireballNote;

    private Rigidbody2D tBody;
    private bool bOnGround = false;
    private Animator tAnim;
    private SpriteRenderer tSprite;
    private float flDrag;
    private CapsuleCollider2D tCollider;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        tBody = GetComponent<Rigidbody2D>();
        tAnim = GetComponent<Animator>();
        tSprite = GetComponent<SpriteRenderer>();
        tCollider = GetComponent<CapsuleCollider2D>();
        audio = GetComponent<AudioSource>();
        flDrag = tBody.drag;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 vPos = tBody.transform.position;
        tAnim.SetBool("Walking", false);
        tAnim.SetBool("Attacking", false);

        if(Input.GetMouseButtonDown(0))
        {
            tAnim.Play("Attack");
            audio.clip = swing;
            audio.Play();
        }

        float flHorizontalDirection = Input.GetAxis("Horizontal");
        float flVerticalDirection = Input.GetAxis("Vertical");

        float flMultiplier = (Mathf.Abs(flHorizontalDirection) > .5f && Mathf.Abs(flVerticalDirection) > .5f) ? .7f : 1.0f;

        if (flHorizontalDirection != 0)
        {
            int nDirection = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            vPos.x += (nDirection * flWalkingSpeed * Time.fixedDeltaTime * flMultiplier);

            UpdateRotation(nDirection);
            tAnim.SetBool("Walking", true);
        }

        if(flVerticalDirection != 0)
        {
            int nDirection = Input.GetAxis("Vertical") > 0 ? 1 : -1;
            vPos.y += (nDirection * flWalkingSpeed * Time.deltaTime * flMultiplier);

            tAnim.SetBool("Walking", true);
        }

        tBody.MovePosition(vPos);

        if (dungeon1 == true)
        {
            Fireball.unlockFireball = true;
        }

        if (dungeon1 == true && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            Instantiate(fireballNote, transform.position, Quaternion.identity);
            dungeon1 = false;
        }
    }

    private void UpdateRotation (int nDirection)
    {
        Vector3 vRot = transform.eulerAngles;
        vRot.y = nDirection > 0 ? 0 : 180;
        transform.eulerAngles = vRot;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HealthPotion")
        {
            for (int i = 0; i < 10; i++)
            {
                if(Health.currentHealth == Health.maxHealth)
                {
                    break;
                }
                else
                {
                    Health.currentHealth += 1;
                }
            }
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Key")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Door")
        {
            if (GameObject.Find("Key") || GameObject.Find("Key(Clone)"))
            {
                Destroy(collision.gameObject);
                Destroy(GameObject.Find("Black").gameObject);
                Destroy(GameObject.Find("BehindDoor").gameObject);
            }
        }
    }

}
