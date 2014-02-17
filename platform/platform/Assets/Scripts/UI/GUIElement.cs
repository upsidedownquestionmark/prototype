using UnityEngine;
using System.Collections;

public class GUIElement : MonoBehaviour {

	protected GUITexture texture;
	protected GUIText text;

	public bool leftAlign;
	public bool topAlign;

	// Use this for initialization
	protected void Start () {
		texture = GetComponent<GUITexture>();
		texture.enabled = true;
		text = GetComponentInChildren<GUIText>();
		text.enabled = true;
	}
	
	// Update is called once per frame
	protected void Update () {
		Rect pixelInset = texture.pixelInset;
		pixelInset.width = 200 * (leftAlign ? 1 : -1);
		pixelInset.height = 38 * (topAlign ? -1 : 1);
		pixelInset.center = new Vector2((125 - Screen.width / 2) * (leftAlign ? 1 : -1),
		                                (Screen.height / 2 - 44) * (topAlign ? 1 :-1));
		texture.pixelInset = pixelInset;

		text.pixelOffset = pixelInset.center + new Vector2(-75, 0);
	}
}
