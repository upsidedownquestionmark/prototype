using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

	void Update () {
		if (Input.GetKey(KeyCode.Escape)) { 
			Application.LoadLevel(0);
		}
	}
}
