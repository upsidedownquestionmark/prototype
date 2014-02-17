using UnityEngine;
using System.Collections;

public class AchievementScene: MonoBehaviour {
	
	public Texture2D coinTex;

	void Update () {
		if (Input.GetKey(KeyCode.Escape)) { 
			Application.LoadLevel(0);
		}
	}

	void OnGUI () {
		if(PlayerPrefs.GetString ("Ach1") == "true")
		{
			GUI.Label (new Rect (10,Screen.height/2f-coinTex.height/4,100,100), coinTex);
		}
		/*Vector3 scoreS = Camera.main.WorldToScreenPoint(new Vector3(-4, -1.5f, 0));
		float ypos = scoreS.y;
		GUI.Box (new Rect(scoreS.x,ypos,400,24),PlayerPrefs.GetString (i+"HScoreName")+" scored: " + PlayerPrefs.GetInt (i+"HScore").ToString());*/
	}
}
