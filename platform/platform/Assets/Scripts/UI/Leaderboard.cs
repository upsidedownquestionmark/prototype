using UnityEngine;
using System.Collections;

public class Leaderboard : MonoBehaviour {
	
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) { 
			Application.LoadLevel(0);
		}
	}

	void OnGUI () {
		//GetHighScores ();
		//string score = PlayerPrefs.GetInt ("playerScore").ToString ();
		//string score = "Score: " + Entity.GetComponent<Entity> ().currentScore.ToString ("0000");
		Vector3 scoreS = Camera.main.WorldToScreenPoint(new Vector3(-4, -1.5f, 0));
		//GUI.Box (new Rect(Screen.width / 2f,scoreS.y,80,24), score);

		float ypos = scoreS.y;
		for(int i =0;i<10;i++)
		{
			if(PlayerPrefs.GetInt (i+"HScore") !=0)
			{
				GUI.Box (new Rect(scoreS.x,ypos,400,24),PlayerPrefs.GetString (i+"HScoreName")+" scored: " + PlayerPrefs.GetInt (i+"HScore").ToString());
				ypos += 40;
			}
		}
	}

	void GetHighScores()
	{
		for(int i =0;i<10;i++)
		{
			Debug.Log (PlayerPrefs.GetString (i+"HScoreName")+" has a score of: " + PlayerPrefs.GetInt (i+"HScore"));
		}
	}
}
