using UnityEngine;
using System.Collections;

public class Prompt : MonoBehaviour {

	public GameObject prompt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "player") {
			prompt.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "player") {
			prompt.SetActive (false);
		}
	}
}
