using UnityEngine;
using System.Collections;

public class PlayerSprite : MonoBehaviour {
	
	private Sprite sprite;
	private PlayerController controller;
	private PlayerPhysics physics;

	// Use this for initialization
	void Start () {
		sprite = GetComponentInChildren<Sprite>();
		controller = GetComponent<PlayerController>();
		physics = GetComponent<PlayerPhysics>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.currentSpeed == 0)
			sprite.SetAnimation (0,0);
		else
			sprite.SetAnimation (4,19, 20, true);
	}
}
