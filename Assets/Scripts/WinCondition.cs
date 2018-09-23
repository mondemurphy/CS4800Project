using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Enemies").transform.childCount == 0)
        {
            anim.SetBool("Win", true);
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
 