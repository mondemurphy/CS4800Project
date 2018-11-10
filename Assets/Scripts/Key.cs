using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "You found a key!");
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        enabled = false;
    }

}
