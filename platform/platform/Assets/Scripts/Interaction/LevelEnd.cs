﻿using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {
	
	public Texture2D winGraphic;
	private bool activated;

	// Use this for initialization
	void Start () {
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		if (activated)
			Application.LoadLevel(2);
			//GUI.DrawTexture (new Rect(0,0,Screen.width,Screen.height), winGraphic);
	}
	
	void OnTriggerEnter (Collider other) {
		if (!activated && other.tag.Equals ("Player")) {
			activated = true;
			other.GetComponent<PlayerController>().AddHighScore (System.DateTime.Now.ToString (),other.GetComponent<PlayerController>().currentScore);
		}
	}
}
