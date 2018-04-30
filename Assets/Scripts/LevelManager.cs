using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string levelToLoad) {

		// Setup the level variable
		if (levelToLoad == "Lightning") { 
			GameManager.gameMode = 2;
			SceneManager.LoadScene("Game");
		} else if (levelToLoad == "Evil") {
			GameManager.gameMode = 1;
			SceneManager.LoadScene("Game");
		}

		// Or load the scene we called
		else {
			SceneManager.LoadScene(levelToLoad);
		}

		
	}

}
