using UnityEngine;
using System.Collections;

public class Sprite : MonoBehaviour {
	
	public int xTiles = 1;
	public int yTiles = 1;
	
	private int currentTile;
	private float maxTime;
	private float currentTime;
	private Vector2 scale;
	private Vector2 offset;
	
	private int currentStart;
	private int currentEnd;
	private int fps;
	
	public bool mirror;
	public bool paused;
	public bool looping;
	

	void Start () {
		currentTile = 0;
		
		fps = 15;
		maxTime = 1.0f / fps;
		currentTime = maxTime;
		
		currentStart = 0;
		currentEnd = xTiles * yTiles - 1;
		mirror = false;
		paused = false;
		looping = true;
		
		// scale is reciprocal of number of tiles
		scale = new Vector2(1.0f / xTiles, 1.0f / yTiles);
		
		updateOffset ();
	}
	
	void LateUpdate () {
		transform.position -= Vector3.forward * transform.position.z;
		
		if (!paused) {
			// update time
			currentTime -= Time.deltaTime;
			
			// update sprite when time runs out
			if (currentTime <= 0.0f) {
				if ((currentTile != currentEnd) || looping) {
					currentTile++;
					if (currentTile > currentEnd)
						currentTile = currentStart;
				}
				
				currentTime += maxTime;
			}
			
			updateOffset();
		}
	}
	
	private void updateOffset() {
		// get tile location
		int xTile = currentTile % xTiles;
		int yTile = currentTile / xTiles;
		
		offset = new Vector2(Mathf.Abs (scale.x * xTile), scale.y * (yTiles - yTile - 1));
		
		// when scale is negative move offset to opposite side of tile
		if (scale.x < 0.0f)
			offset.x -= scale.x;
		
		// set offset
		renderer.material.SetTextureOffset ("_MainTex", offset);
		
		// negative scale mirrors sprite
		scale.x = (mirror ? -1.0f : 1.0f) / xTiles;
		
		// set scale
		renderer.material.SetTextureScale ("_MainTex", scale);
	}
	
	public void SetAnimation(int start, int end) {
		SetAnimation(start, end, fps, false);
	}
	
	public void SetAnimation(int start, int end, int fps) {
		SetAnimation(start, end, fps, false);
	}
	
	public void SetAnimation(int start, int end, int fps, bool retainCurrentTile) {
		if (start != currentStart
			|| end != currentEnd) {
			currentStart = start;
			currentEnd = end;
			
			if (!retainCurrentTile)
				currentTile = start;
			
			UpdateFPS(fps);
		}
	}
	
	public void UpdateFPS(int fps) {
		// convert current time to within new fps's possible time range
		currentTime = currentTime * this.fps / fps;
		
		this.fps = fps;
		maxTime = 1.0f / fps;
	}
}
