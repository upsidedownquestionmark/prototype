using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float velocity;
	public float lifetime;

	private float timeRemaining;

	// Use this for initialization
	void Start () {
		timeRemaining = lifetime;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += transform.forward * velocity * Time.deltaTime;
		transform.localPosition += Vector3.back * transform.localPosition.z;

		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0.0f)
			Destroy (gameObject);
	}

	void OnTriggerEnter (Collider c) {
		Debug.Log (c.transform.tag);
		if (c.tag.Equals ("Player")) {
			c.GetComponentInChildren<Entity>().TakeDamage(5);
			Destroy (gameObject);
		} else if (c.tag.Equals ("Block")) {
			Destroy (gameObject);
		}


	}
}
