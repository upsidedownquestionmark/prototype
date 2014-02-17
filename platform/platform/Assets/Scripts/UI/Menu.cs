using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public Texture2D startTex;
	public Texture2D leaderboardTex;
	public Texture2D achievementListTex;
	public Texture2D resetTex;
	public Texture2D quitTex;

	void OnGUI () {
		Vector3 start = Camera.main.WorldToScreenPoint(new Vector3(-4, -1.5f, 0));
		
		if (GUI.Button (new Rect (start.x,start.y,startTex.width,startTex.height), startTex, GUIStyle.none)) {
			Application.LoadLevel(1);
		}
		
		start.y += startTex.height + 20;
		
		if (GUI.Button (new Rect (start.x, start.y, leaderboardTex.width, leaderboardTex.height), leaderboardTex, GUIStyle.none)) {
			Application.LoadLevel(4);
		}
		
		start.y += leaderboardTex.height + 20;
		
		if (GUI.Button (new Rect (start.x, start.y, achievementListTex.width, achievementListTex.height), achievementListTex, GUIStyle.none)) {
			Application.LoadLevel(5);
		}

		start.y += achievementListTex.height + 20;
		
		if (GUI.Button (new Rect (start.x, start.y, resetTex.width, resetTex.height), resetTex, GUIStyle.none)) {
			PlayerPrefs.DeleteAll();
		}
		
		start.y += resetTex.height + 20;

		if (GUI.Button (new Rect (start.x, start.y, quitTex.width, quitTex.height), quitTex, GUIStyle.none)) {
			Application.Quit();
		}

		if (Input.GetKey(KeyCode.Escape)) { Application.Quit();
		}
	}
	}
