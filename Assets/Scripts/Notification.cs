using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour {

    public GameObject canvas;

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ExamplePlayerController>().enabled = false;
	}

    public void CloseNotification()
    {
        Destroy(canvas);
        GameObject.FindGameObjectWithTag("Player").GetComponent<ExamplePlayerController>().enabled = true;
    }
}
