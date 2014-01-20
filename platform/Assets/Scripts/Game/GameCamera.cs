﻿using UnityEngine;
using System;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	private Transform target;
	private float trackSpeed = 12;
	
	public void SetTarget(Transform t){
		target = t;
	}
	
	void LateUpdate(){
		if(target){
			
			float x = IncrementTowards (transform.position.x, target.position.x,trackSpeed);
			float y = IncrementTowards (transform.position.y, target.position.y,trackSpeed);
			transform.position = new Vector3(x,y,transform.position.z);
		}
	}
	
	void OnGUI() {
		string score = "Score: " + 0;
		GUI.Label (new Rect(600,0,500,30), score);
	}
	
	//Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a){
		if(n==target){
			return n;
		}
		else{
			float dir = Mathf.Sign (target - n); //must n be increased or decreased to get closer to target
			n +=a * Time.deltaTime * dir;
			return(dir==Mathf.Sign (target-n))? n: target; //if n has now passed target then return target, otherwise return n
		}
	}
}