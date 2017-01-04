using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	public GameObject darkness;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchOn() {
		darkness.SetActive (false);
	}

	public void SwitchOff() {
		darkness.SetActive (true);
	}
}
