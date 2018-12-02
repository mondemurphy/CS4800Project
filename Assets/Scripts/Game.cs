using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Game
{
    public static Game current;
    public Character knight;
    public int scene;
    //public Character rogue;
    //public Character wizard;

    public Game()
    {
        knight = new Character();
        scene = 1;
        //rogue = new Character();
        //wizard = new Character();
    }

}