using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	private LevelManager levelManager;
	public GameObject splashScreenCanvas;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BeginGame() {
		splashScreenCanvas.SetActive (false);
		levelManager.BeginGame ();
	}

	public void Quit() {
		Application.Quit ();
	}
}
