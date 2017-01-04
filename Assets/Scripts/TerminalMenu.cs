using UnityEngine;
using UnityEngine.UI;
using System;

public class TerminalMenu : MonoBehaviour {

	private LevelManager levelManager;
	private PlayerController player;

	public GameObject terminalCanvas;
	public GameObject terminalField;
	public GameObject inputField;

	Text terminalText;
	Text inputText;

	private bool playerInRange;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
		player = FindObjectOfType<PlayerController> ();

		terminalText = terminalField.GetComponent<Text> ();
		inputText = inputField.GetComponent<Text> ();

		playerInRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (levelManager.terminalLive) {
			terminalCanvas.SetActive (true);
			                
		} else {
			terminalCanvas.SetActive (false);
		}
		
		if (Input.GetKeyDown (KeyCode.Tab) && playerInRange) {
			levelManager.terminalLive = !levelManager.terminalLive;
		}
	}

	private void OnTriggerEnter2D (Collider2D other) {
		if(other.name == "player") {
			playerInRange = true;
		}
	}
	
	public void OnTriggerExit2D (Collider2D other) {
		if(other.name == "player") {
			playerInRange = false;
			terminalText.text = "> COMMAND: ";
		}
	}

	// =================
	// TERMINAL COMMANDS
	// =================

	public void Command(string cmd) {
		// can't manage to clear text field
		cmd = cmd.Replace (System.Environment.NewLine, "");
		terminalText.text += "[" + cmd + "]";
		string[] keywords = cmd.Split (' ');

		string action, identifier = null;

		if (keywords.Length == 0) {
			WriteLine ();
		} else if (keywords.Length == 1) {
			HelpText (keywords [0]);
		} else if (keywords.Length == 2) {
			action = keywords [0];
			identifier = keywords [1];

			FullCommand (action, identifier);
		} else {
			WriteLine ();
		}
	}

	private void WriteLine(string text) {
		terminalText.text += "\n" + text;
	}

	private void WriteLine() {
		terminalText.text += "\n" + "[Command not recognised.]";
		PromptLine ();
	}

	private void PromptLine() {
		terminalText.text += "\n" + "\n" + "> COMMAND: ";
	}

	private void HelpText(string action) {
		if (action == "reboot") {
			WriteLine ("REBOOT keyword must be followed by identifier.");
			WriteLine ("Syntax: REBOOT [lights|servers]");
			PromptLine ();
		} else {
			WriteLine ();
		}
	}

	private void PlayRecognised() {
		terminalCanvas.GetComponent<AudioSource> ().Play ();
	}

	private void FullCommand(string action, string identifier) {
		if (action == "reboot") {
			if (identifier == "lights") {
				WriteLine ("Light controllers rebooting...");
				WriteLine ("Estimated reboot time: 5 seconds");
				StartCoroutine (levelManager.Lights ());
			} else {
				WriteLine ();
			}
		} else if (action == "mode") {
			if (identifier == "godmode") {
				if (levelManager.godmodeOn) {
					WriteLine ("Godmode Disabled");
					levelManager.godmodeOn = false;
				} else {
					WriteLine ("Godmode Enabled");
					levelManager.godmodeOn = true;
				}
			} else if (identifier == "bighead") {
				if (levelManager.bigHeadMode) {
					WriteLine ("Big Head Mode Disabled");
					levelManager.bigHeadMode = false;
				} else {
					WriteLine ("Big Head Mode Enabled");
					levelManager.bigHeadMode = true;
				}
			} else {
				WriteLine ();
			}
		} else if (action == "clear") {
			if (identifier == "all") {
				terminalText.text = "> COMMAND: ";
			}
		} else if (action == "guardspeed") {
			int j;
			if (Int32.TryParse(identifier, out j)) {
				levelManager.SetGuardSpeed(j);
				WriteLine ("Guard Speed set to: " + j + " (DEFAULT 2)");
			} else {
				WriteLine ("GUARDSPEED must be followed by integer value (default 2).");
				WriteLine ("Syntax: GUARDSPEED[INTEGER]");
			}
		} else {
			WriteLine ();
		}

		PlayRecognised ();
	}
}
