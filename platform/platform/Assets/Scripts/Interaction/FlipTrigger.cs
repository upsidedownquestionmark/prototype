using UnityEngine;
using System.Collections;

public class FlipTrigger : MonoBehaviour
{
	
	public Transform level;
	public float rotate;
	public float rotateTime;
	
	private bool rotated = false;
	private bool rotating = false;
	private float rotateStart = 0.0f;
	
	private Quaternion initialRotation;
	private Vector3 initialPosition;
	private Vector3 rotatePoint;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void OnTriggerEnter (Collider c)
	{
		if (c.tag == "Player") {
			Time.timeScale = 0;
			rotateStart = Time.realtimeSinceStartup;
			initialPosition = level.localPosition;
			initialRotation = level.localRotation;
			rotatePoint = transform.position;
			rotating = true;
		}
	}
	
	void OnGUI () {
		if (rotating) {
			level.localPosition = initialPosition;
			level.localRotation = initialRotation;
			
			if (Time.realtimeSinceStartup - rotateStart > rotateTime) {
				level.RotateAround (rotatePoint, Vector3.up,
					rotate * (rotated ? -1 : 1));
				((BoxCollider)collider).center += new Vector3 (0.5f * (rotated ? 1 : -1), 0.0f, 0.5f * (rotated ? 1 : -1));
				rotated = !rotated;
				Time.timeScale = 1.0f;
				rotating = false;
			} else {
				level.RotateAround (rotatePoint, Vector3.up,
					(Time.realtimeSinceStartup - rotateStart) / rotateTime * rotate * (rotated ? -1 : 1));
			}
		}
	}
}
