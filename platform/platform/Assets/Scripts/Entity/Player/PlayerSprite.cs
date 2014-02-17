using UnityEngine;
using System.Collections;

public class PlayerSprite : MonoBehaviour {
	
	public Sprite sprite;
	private PlayerController controller;
	private PlayerPhysics physics;

	private bool jumping;

	// Use this for initialization
	void Start () {
		sprite = GetComponentInChildren<Sprite>();
		controller = GetComponent<PlayerController>();
		physics = GetComponent<PlayerPhysics>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale > 0) {
			if (!jumping) {
				if (!physics.grounded) {// && controller.amountToMove.y < -controller.gravity * Time.deltaTime) {
					sprite.SetAnimation (35,35);
					sprite.looping = true;
				} else if (controller.currentSpeed == 0) {
					sprite.SetAnimation (0,0);
					sprite.looping = true;
				} else {
					sprite.SetAnimation (4,19, 20, true);
					sprite.looping = true;
				}
			}
		}
	}

	public void Jump () {
		sprite.SetAnimation (20,35,20,false);
		sprite.looping = false;
		jumping = true;
	}

	public void DoubleJump () {
		sprite.SetAnimation (20,35,20,false);
		sprite.looping = false;
		jumping = true;
	}

	public void Reset () {
		jumping = false;
	}
}
