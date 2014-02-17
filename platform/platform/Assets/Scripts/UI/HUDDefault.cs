using UnityEngine;
using System.Collections;

public class HUDDefault : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.zero + new Vector3(0.5f,0.5f);
	}
}
