using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	//Player Handling
	public float gravity = 20;
	public float walkspeed = 8;
	public float runspeed = 12;
	public float accleration = 30;
	public float jumpHeight = 12;
	public float slideDeceleration = 10;
	
	private float animationSpeed;	
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	
	//States
	private bool jumping;
	private bool sliding;
	
	private PlayerPhysics playerPhysics;
	private Animator animator;

	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		animator = GetComponent<Animator>();
		
		animator.SetLayerWeight(1,1);
	}
	
	void Update () {
		//reset acceleration upon collision
		if(playerPhysics.movementStopped){
			targetSpeed =0;
			currentSpeed=0;
		}
		
		//if player is touching ground
		if(playerPhysics.grounded){
			amountToMove.y = 0;
		
			if(jumping){
				jumping = false;
				animator.SetBool("Jumping",false);
			}
			
			if(sliding){
				if(Mathf.Abs (currentSpeed)<.25f){
					sliding = false;
					animator.SetBool("Sliding",false);
					
					playerPhysics.ResetCollider();
				}
			}
			
			//jump
			if(Input.GetButtonDown ("Jump")){
				amountToMove.y = jumpHeight;
				jumping = true;
				animator.SetBool("Jumping",true);
			}
			
			//sliding
			if(Input.GetButtonDown ("Slide")){
				sliding = true;
				animator.SetBool("Sliding",true);
				targetSpeed = 0;
				
				playerPhysics.SetCollider(new Vector3(10.3f,1.5f,3f),new Vector3(.25f,.75f,0));
			}
			
		}
		
		animationSpeed = IncrementTowards (animationSpeed,Mathf.Abs (targetSpeed),accleration);
		animator.SetFloat ("Speed",animationSpeed);
		
		//Input
		if(!sliding){
			float speed = (Input.GetButton("Run"))?runspeed:walkspeed;
			targetSpeed = Input.GetAxisRaw("Horizontal")*speed;
			currentSpeed = IncrementTowards(currentSpeed,targetSpeed,accleration);
			
			//face direction
			float moveDir = Input.GetAxisRaw ("Horizontal");
			if(moveDir!=0){
				transform.eulerAngles = (moveDir>0)?Vector3.up * 180:Vector3.zero;
			}
		}
		else{
			currentSpeed = IncrementTowards(currentSpeed,targetSpeed,slideDeceleration);
		}
		
		//Amount to Move
		amountToMove.x = currentSpeed;
		amountToMove.y -=gravity*Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);
		
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
