using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	private PlayerController player;
	private LevelManager levelManager;

	private Animator anim;
	public float moveSpeed;
	public bool movingRight;
	public float viewDistance;

	public Transform wallCheck;
	public LayerMask whatIsWall;
	private bool hittingWall;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		player = FindObjectOfType<PlayerController> ();
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Enemy Movement

		hittingWall = Physics2D.OverlapPoint (wallCheck.position, whatIsWall);

		if (hittingWall)
			movingRight = !movingRight;

		if (!player.isCaught) {
			if (movingRight) {
				transform.localScale = new Vector3 (1f, 1f, 1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			} else {
				transform.localScale = new Vector3 (-1f, 1f, 1f);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			}
		} else {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}


		// Enemy Vision

		if(!player.isCaught && CheckModifiers() && !levelManager.behindCover && Mathf.Abs(player.transform.position.y - this.transform.position.y) < 1) {
			if (movingRight) { // facing right
				if(player.transform.position.x - this.transform.position.x > 0 && CheckPlayerBounds()) { // player on right and within bounds
					PlayerCaught();
				}
			} else { // facing left
				if(player.transform.position.x - this.transform.position.x < 0 && CheckPlayerBounds()) { // player on left and within bounds
					PlayerCaught();
				}
			}
		}
	}

	private void PlayerCaught() {
		player.isCaught = true;
		anim.Play ("EnemyAlerted");
		GetComponent<AudioSource> ().Play ();
	}

	private bool CheckModifiers() {
		return (!levelManager.lightsOff && !levelManager.godmodeOn);
	}

	private bool CheckPlayerBounds() {
		return (Mathf.Abs (player.transform.position.x - this.transform.position.x) < viewDistance);
	}

	public void RespawnPlayer() {
		levelManager.RespawnPlayer ();
	}
}
