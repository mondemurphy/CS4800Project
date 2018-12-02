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
            canvas.enabled = !canvas.enabled;
            if (canvas.enabled == true)
            {
                GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ExamplePlayerController>().enabled = false;
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
                {
                    GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<FrogController>().enabled = false;
                }
            }
            else
            {
                GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ExamplePlayerController>().enabled = true;
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
                {
                    GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<FrogController>().enabled = true;
                }
            }
        }
	}

    public void ReturnToGame()
    {
        canvas.enabled = false;
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<ExamplePlayerController>().enabled = true;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<FrogController>().enabled = true;
        }
    }
}
