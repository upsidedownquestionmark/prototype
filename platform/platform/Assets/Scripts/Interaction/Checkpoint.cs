using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	private bool activated;

	// Use this for initialization
	void Start () {
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		if (!activated && other.tag.Equals ("Player")) {
			other.transform.GetComponent<PlayerController>().SetCheckpoint(transform.position);
			activated = true;
		}
	}
}
