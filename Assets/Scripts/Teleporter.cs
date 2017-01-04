using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public Teleporter partner;
	private PlayerController player;
	private bool playerInRange;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) && playerInRange) {
			player.transform.position = partner.transform.position;
			//player.ExitDoor ();
		}
	}

	public void FinishTransition() {

	}

	private void OnTriggerEnter2D (Collider2D other) {
		if(other.name == "player") {
			playerInRange = true;
		}
	}

	public void OnTriggerExit2D (Collider2D other) {
		if(other.name == "player") {
			playerInRange = false;
		}
	}
}
