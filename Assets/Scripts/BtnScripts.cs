using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnScripts : MonoBehaviour {
	
	public void NewGame () {
        Game game = new Game();
        Game.current = game;
        SceneManager.LoadScene(1);
	}

    public void ContinueGame()
    {
        SaveLoad.Load();
        Experience.vLevel = SaveLoad.savedGames[SaveLoad.savedGames.Count - 1].knight.level;
        Health.currentHealth = SaveLoad.savedGames[SaveLoad.savedGames.Count - 1].knight.health;
        SceneManager.LoadScene(SaveLoad.savedGames[SaveLoad.savedGames.Count - 1].scene);
    }

    public void SaveGame()
    {
        Game.current.knight.health = Health.currentHealth;
        Game.current.knight.level = Experience.vLevel;
        Game.current.scene = SceneManager.GetActiveScene().buildIndex;
        SaveLoad.Save();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
