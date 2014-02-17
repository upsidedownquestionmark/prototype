using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float fireInterval;
	public float fireVelocity;
	public float bulletLifetime;

	public Transform bullet;

	private float lastFire;
	
	// Use this for initialization
	void Start () {
		lastFire = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		lastFire += Time.deltaTime;

		if (lastFire > fireInterval) {
			lastFire -= fireInterval;

			Transform t = Instantiate (bullet) as Transform;
			t.position = transform.position;
			t.localRotation = transform.rotation;

			Bullet newBullet = t.GetComponent <Bullet>();
			newBullet.velocity = fireVelocity;
			newBullet.lifetime = bulletLifetime;
		}
	}
}
