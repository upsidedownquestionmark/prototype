using UnityEngine;
using System.Collections;

public class Timer : GUIElement {
	
	public float timeLimit;
	public float elapsedTime { get; private set; }
	
	public bool timeUp { get; private set; }

	// Use this for initialization
	void Start () {
		elapsedTime = 0;
		timeUp = false;

		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!timeUp) {
			elapsedTime += Time.deltaTime;
			
			if (elapsedTime >= timeLimit) {
				timeUp = true;
				elapsedTime = timeLimit;
			}
		}

		text.text = "Time: " + (timeLimit - elapsedTime).ToString ("000");

		base.Update ();
	}
}
