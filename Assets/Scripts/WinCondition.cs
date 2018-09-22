using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Enemies").transform.childCount == 0)
        {
            anim.SetBool("Win", true);
        }
    }
}
