using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class WinCondition : MonoBehaviour {

    public AudioClip win;

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
            PlaySound();
            ExamplePlayerController.dungeon1 = true;
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            Invoke("ReturnHome", 4f);
        }
    }

    private void PlaySound()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().clip = win;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void ReturnHome()
    {
        enabled = false;
        SceneManager.LoadScene("Home");
    }
}
 