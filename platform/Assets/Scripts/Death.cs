using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider c){
		if(c.tag == "Player"){
			c.GetComponent<Entity>().TakeDamage (1);
		}
	}
	
}
