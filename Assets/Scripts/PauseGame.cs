using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

    public Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = true;
        }
	}

    public void ReturnToGame()
    {
        canvas.enabled = false;
    }
}
