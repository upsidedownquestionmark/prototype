using UnityEngine;
using System.Collections;

public class AchievmentManagerScript : MonoBehaviour {

	private Texture2D Tex;
	public float achTime;
	private float achStart = 0.0f;
	// Use this for initialization
	
	// Update is called once per frame

	public void unlockAchievement(Texture2D achTex){
		achStart = Time.realtimeSinceStartup;
		Tex = achTex;
		Debug.Log ("ding");
	}

	void OnGUI(){
		if(Tex!=null && Time.realtimeSinceStartup - achStart <achTime)
			GUI.Box (new Rect (Screen.width -120,10,100,50), Tex);
	}
}
