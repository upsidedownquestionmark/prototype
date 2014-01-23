using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void OnGUI () {
		if (GUI.Button (new Rect (10,10,150,100), "Play")) {
			Application.LoadLevel(1);
		}
		if (GUI.Button (new Rect (10,200,150,100), "Quit")) {
			Application.Quit();
		}

		if (Input.GetKey(KeyCode.Escape)) { Application.Quit();
		}
	}
	}
