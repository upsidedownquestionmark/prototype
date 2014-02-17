using UnityEngine;
using System.Collections;

public class AchievementList : MonoBehaviour {

	private string ach1 = "false";
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString("Ach1",ach1);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
