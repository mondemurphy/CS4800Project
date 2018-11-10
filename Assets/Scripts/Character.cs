using UnityEngine;
using System.Collections;

[System.Serializable]
public class Character
{
    public string name;
    public int level;
    public int health;

    public Character()
    {
        this.name = "";
        this.level = 1;
        this.health = 100;
    }
}