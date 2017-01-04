using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour {

	private LevelManager levelManager;
	public ElevatorController partner;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "player") {
			anim.Play ("ElevatorOpen");
			partner.anim.Play ("ElevatorOpen");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "player") {
			anim.Play ("ElevatorClose");
		}
	}
}
