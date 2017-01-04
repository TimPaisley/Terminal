using UnityEngine;
using System.Collections;

public class FullCover : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "player") {
			levelManager.behindCover = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "player") {
			levelManager.behindCover = false;
		}
	}
}
