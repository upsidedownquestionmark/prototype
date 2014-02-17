using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	public Texture2D startTex;
	public Texture2D leaderboardTex;
	public Texture2D quitTex;
	
	void OnGUI () {
		string score = PlayerPrefs.GetInt ("playerScore").ToString ();
		//string score = "Score: " + Entity.GetComponent<Entity> ().currentScore.ToString ("0000");
		Vector3 start = Camera.main.WorldToScreenPoint(new Vector3(-5, -1.5f, 0));
		Vector3 scoreS = Camera.main.WorldToScreenPoint(new Vector3(-5, -2.75f, 0));
		GUI.Box (new Rect(Screen.width / 2f,scoreS.y,80,24), score);
		
		if (GUI.Button (new Rect (start.x,start.y,startTex.width,startTex.height), startTex, GUIStyle.none)) {
			Application.LoadLevel(1);
		}
		
		start.y += startTex.height + 20;
		
		if (GUI.Button (new Rect (start.x, start.y, leaderboardTex.width, leaderboardTex.height), leaderboardTex, GUIStyle.none)) {
			Application.LoadLevel(4);
		}
		
		start.y += leaderboardTex.height + 20;
		
		if (GUI.Button (new Rect (start.x, start.y, quitTex.width, quitTex.height), quitTex, GUIStyle.none)) {
			Application.Quit();
		}
		
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
