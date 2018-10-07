using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExamplePlayerController : MonoBehaviour {

    public float flWalkingSpeed = 1.0f;
    public int nextLevel = 1;

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
	void FixedUpdate () {
        Vector2 vPos = tBody.transform.position;
        tAnim.SetBool("Walking", false);
        tAnim.SetBool("Attacking", false);

        if(Input.GetMouseButtonDown(0))
        {
            tAnim.Play("Attack");
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
    }

    private void UpdateRotation (int nDirection)
    {
        Vector3 vRot = transform.eulerAngles;
        vRot.y = nDirection > 0 ? 0 : 180;
        transform.eulerAngles = vRot;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "LevelChanger")
        {
            enabled = false;
            SceneManager.LoadScene(nextLevel);
        }

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Sprite Open = Resources.Load<Sprite>("Assets/2D Hand Painted - Dungeon Tileset/Tilemaps/Dungeon@128x128_238.png"); ;
        collision.gameObject.GetComponent<SpriteRenderer>().sprite = Open;
    }

}
