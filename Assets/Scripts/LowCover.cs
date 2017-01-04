using UnityEngine;
using System.Collections;

public class LowCover : MonoBehaviour {

	private LevelManager levelManager;
	private PlayerController player;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "player") {
			levelManager.behindLowCover = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "player") {
			levelManager.behindLowCover = false;
		}
	}
}
