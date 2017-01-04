using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	/*
	 * Priorities:
	 * 0 - Background Walls
	 * 1 - Use Objects
	 * 2 - Player
	 * 3 - Cover Items
	 * 4 - Enemies
	*/

	public GameObject respawnPoint;
	public GameObject killScreen;

	private PlayerController player;
	public LightController[] lights;
	public EnemyPatrol[] enemies;

	public bool gamePaused;
	public bool terminalLive;
	public bool splashScreenActive;

	public bool behindCover;
	public bool behindLowCover;

	public bool lightsOff;
	public bool godmodeOn;
	public bool bigHeadMode;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		lights = FindObjectsOfType<LightController> ();
		enemies = FindObjectsOfType<EnemyPatrol> ();

		behindCover = false;
		splashScreenActive = true;

		Time.timeScale = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (behindLowCover) {
			if (player.isDucking) {
				behindCover = true;
			} else {
				behindCover = false;
			}
		}

		if (gamePaused || terminalLive) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}

		// check bigheadmode
		player.anim.SetBool ("BigHead", bigHeadMode);
	}

	public void BeginGame() {
		Time.timeScale = 1f;
	}

	public void RespawnPlayer() {
		Debug.Log ("Player Respawn");
		GetComponent<AudioSource> ().Play ();
//		killScreen.SetActive (true);
//		yield return new WaitForSeconds (1f);
//		killScreen.SetActive (false);
		player.transform.position = respawnPoint.transform.position;
		player.isCaught = false;
	}

	public IEnumerator Lights() {
		for (int i = 0; i < lights.Length; i++) { lights[i].SwitchOff(); }
		lightsOff = true;
		yield return new WaitForSeconds (5f);
		for (int i = 0; i < lights.Length; i++) { lights[i].SwitchOn(); }
		lightsOff = false;
	}

	public void SetGuardSpeed (int speed) {
		for (int i = 0; i < enemies.Length; i++) {
			enemies[i].moveSpeed = speed;
		}
	}
}
