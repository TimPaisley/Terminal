using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private LevelManager levelManager;
	public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (levelManager.gamePaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			levelManager.gamePaused = !levelManager.gamePaused;
		}
	}

	public void Resume() {
		levelManager.gamePaused = false;
	}

	public void Restart() {
		levelManager.RespawnPlayer ();
		levelManager.gamePaused = false;
	}

	public void Quit() {
		Application.Quit ();
	}
}
