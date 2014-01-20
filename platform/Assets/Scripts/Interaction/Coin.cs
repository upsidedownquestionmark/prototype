using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player"){
			c.GetComponent<Entity>().addScore (10);
			Destroy(this.gameObject);
		}
	}
}
