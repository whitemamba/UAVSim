using UnityEngine;
using System.Collections;

public class GUICrossHair : MonoBehaviour {

	public Texture crosshairImage;


	// Use this for initialization
	void Start () {
	


	}

	void OnGUI()
	{
		float xMin = (Screen.width*3 / 4) - (crosshairImage.width / 2);
		float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);

		float xMin2 = (Screen.width*1 / 4) - (crosshairImage.width / 2);
		float yMin2 = (Screen.height / 2) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin2, yMin2, crosshairImage.width, crosshairImage.height), crosshairImage);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
