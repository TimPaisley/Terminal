using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x, player.gameObject.transform.position.y, this.gameObject.transform.position.z);
	}
}
