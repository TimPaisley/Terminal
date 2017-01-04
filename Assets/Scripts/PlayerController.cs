using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private LevelManager levelManager;

	public float moveSpeed;
	public bool isDucking;
	private float moveVelocity;

	public Animator anim;
	public bool isCaught;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		anim = GetComponent<Animator> ();

		isDucking = false;
		isCaught = false;
	}
	
	// Update is called once per frame
	void Update () {

		bool noMenuUp = !levelManager.gamePaused && !levelManager.terminalLive;
		moveVelocity = 0f;

		if (Input.GetKey (KeyCode.D) && !isDucking && !isCaught && noMenuUp) {
			moveVelocity = moveSpeed;
		}

		if (Input.GetKey (KeyCode.A) && !isDucking && !isCaught && noMenuUp) {
			moveVelocity = -moveSpeed;
		}

		if (Input.GetKey (KeyCode.S) && noMenuUp) {
			isDucking = true;
		} else {
			isDucking = false;
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x));
		anim.SetBool ("Ducking", isDucking);

		if (GetComponent<Rigidbody2D> ().velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if (GetComponent<Rigidbody2D> ().velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);

	}
}
