using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public Texture2D coinTex;

	void Update () {
	
	}

	void OnTriggerEnter(Collider c){
		if(c.tag == "Player"){
			if(PlayerPrefs.GetString ("Ach1") == "false")
			{
				PlayerPrefs.SetString ("Ach1","true");
				c.GetComponent<AchievmentManagerScript>().unlockAchievement (coinTex);
				Debug.Log (PlayerPrefs.GetString ("Ach1").ToString ());
			}
			c.GetComponent<PlayerController>().addScore (10);
			Destroy(this.gameObject);
		}
	}
}
