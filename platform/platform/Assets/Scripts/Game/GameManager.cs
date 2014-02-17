using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Font font;
	
	public GameObject playerPrefab;
	private GameObject playerInstance;
	private GameCamera cam;
	private Timer timer;
	public float totalScore = 0;
	// Use this for initialization
	void Start () {
		cam = GetComponent<GameCamera>();
		timer = GetComponentInChildren<Timer>();

		PlayerPrefs.SetInt ("playerScore", 0);
		SpawnPlayer ();
	}
	
	void Update () {
		if (timer.timeUp)
			Application.LoadLevel("Lose");
		
		if (Input.GetKey(KeyCode.Escape)) { 
			Application.LoadLevel(0);
		}
	}
	
	void OnGUI() {
		GUIStyle style = new GUIStyle(GUI.skin.box);
		style.font = font;

		string score = "Score: " + playerInstance.GetComponent<PlayerController> ().currentScore.ToString ("0000");
		GUI.Box (new Rect(Screen.width / 2f - 40f,10,80,24), score, style);
		
		style.alignment = TextAnchor.MiddleLeft;
		//GUI.Box (new Rect(10,10,75,24),
		//		 "Time: " + (timer.timeLimit - timer.elapsedTime).ToString ("000"), style);
	}
	
	private void SpawnPlayer(){
		playerInstance = (GameObject)Instantiate (playerPrefab);
		cam.SetTarget(playerInstance.transform);
	}
}
