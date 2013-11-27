using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
	
	public float health;
	public float currentScore;
	public bool dead = false;
	
	
	public void TakeDamage(float dmg){
		health -=dmg;
		
		if(health <= 0){
			Die();
		}
	}

	public void addScore(float score){
		currentScore += score;
		Debug.Log (currentScore);
	}

	public void Die(){
		Debug.Log ("Die");
		dead = true;
	}
}
