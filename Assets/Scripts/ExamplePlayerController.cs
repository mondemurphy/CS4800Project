using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayerController : MonoBehaviour {

    public float flWalkingSpeed = 1.0f;

    private Rigidbody2D tBody;
    private bool bOnGround = false;
    private Animator tAnim;
    private SpriteRenderer tSprite;
    private float flDrag;
    private CapsuleCollider2D tCollider;

	// Use this for initialization
	void Start () {
        tBody = GetComponent<Rigidbody2D>();
        tAnim = GetComponent<Animator>();
        tSprite = GetComponent<SpriteRenderer>();
        tCollider = GetComponent<CapsuleCollider2D>();
        flDrag = tBody.drag;
	}
	
	// Update is called once per frame
	void Update () {
        tAnim.SetBool("Walking", false);
        UpdateOnGround();

        if (Input.GetButton("Horizontal") && bOnGround)
        {
            float flDirection = Input.GetAxis("Horizontal");
            tSprite.flipX = flDirection > 0 ? false : true;
            tBody.velocity = new Vector2(flDirection * flWalkingSpeed, 0);

            tAnim.SetBool("Walking", true);
        }
	}

    private void UpdateOnGround()
    {
        bOnGround = false;
        tBody.drag = 0;
        Vector2 vPos = transform.position;
        vPos.y -= 1.3f;
        if (Physics2D.Raycast(transform.position, new Vector2(0, -1), 1))
        {
            bOnGround = true;
            tBody.drag = flDrag;
        }
    }
}
