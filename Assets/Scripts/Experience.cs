using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour {

    //current level
    public static int vLevel = 1;
    //current exp amount
    public static int vCurrExp = 0;
    //exp amount needed for lvl 1
    public static int vExpBase = 10;
    //exp amount left to next levelup
    public static int vExpLeft = 10;
    //modifier that increases needed exp each level
    public static float vExpMod = 1.15f;

    public Text text;

    private string gui = "";

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GainExp(3);
        }

        text.text = "Lvl. " + vLevel;
    }

    //leveling methods
    public void GainExp(int e)
    {
        vCurrExp += e;
        if (vCurrExp >= vExpLeft)
        {
            LvlUp();
        }
    }
    void LvlUp()
    {
        vCurrExp -= vExpLeft;
        vLevel++;
        float t = Mathf.Pow(vExpMod, vLevel);
        vExpLeft = (int)Mathf.Floor(vExpBase * t);
        gui = "Level Up!";
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), gui);
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
        gui = "";
    }
}