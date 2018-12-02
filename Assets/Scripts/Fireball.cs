using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public Rigidbody2D fireball;
    public float fireballSpeed = 8;
    public static bool unlockFireball = false;
	
	// Update is called once per frame
	void Update () {
        if (unlockFireball == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (GameObject.FindGameObjectsWithTag("Player")[0].transform.eulerAngles.y == 180)
                {
                    gameObject.GetComponent<Animator>().Play("Cast");
                    var fireballInst = Instantiate(fireball, new Vector3(transform.position.x - .5f, transform.position.y - .25f, 0), Quaternion.Euler(new Vector2(0, 180)));
                    fireballInst.velocity = new Vector2(-fireballSpeed, 0);
                }
                else
                {
                    gameObject.GetComponent<Animator>().Play("Cast");
                    var fireballInst = Instantiate(fireball, new Vector3(transform.position.x + .5f, transform.position.y - .25f, 0), Quaternion.Euler(new Vector2(0, 0)));
                    fireballInst.velocity = new Vector2(fireballSpeed, 0);
                }
            }
        }
	}
}
