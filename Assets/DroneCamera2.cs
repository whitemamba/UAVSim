using UnityEngine;
using System.Collections;

public class DroneCamera2 : MonoBehaviour {
	
	public float mousesensitivity = 0.5f;
	public float rotUpDown = 0;
	public float rotLeftRight = 0;
	public float hitSeconds;
	public RaycastHit hit;
	// Use this for initialization
	void Start () {
		hitSeconds = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		rotUpDown -= Input.GetAxis ("Vertical2") * mousesensitivity;
		rotUpDown = Mathf.Clamp (rotUpDown, 0, 180);
		transform.localRotation = Quaternion.Euler (rotUpDown, 0, 0);
		
		rotLeftRight += Input.GetAxis ("Horizontal2") * mousesensitivity;
		rotLeftRight = Mathf.Clamp (rotLeftRight, -70, 70);
		transform.Rotate (0, rotLeftRight, 0);
		
		var x = Screen.width / 4;
		var y = Screen.height*1 / 4;
		var ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y, 0));
		if (Physics.SphereCast (ray.origin, 10.0f, ray.direction, out hit)) {
			
			if (hit.collider.tag=="Tank"){
				hitSeconds += 1*Time.deltaTime;
				
				if (hitSeconds >= 0.5f){
					hit.collider.tag="Tank_Marked";
					Debug.Log("Marked Tank!!");}
			}
			
			else if (hit.collider.tag=="Tank_Marked"){
				Debug.Log("Tank already marked!!");
			}
			
			else {
				hitSeconds = 0.0f;
				Debug.Log("Not hitting anything!!");
			}
			
		}
		Debug.DrawRay (ray.origin, ray.direction*1000);
		
		
	}
}
