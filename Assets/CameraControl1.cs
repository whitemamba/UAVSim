using UnityEngine;
using System.Collections;

public class CameraControl1 : MonoBehaviour {
	
	public GameObject plane;
	
	private Vector3 offset;
	private Vector3 rotationoffset;
	private float yRotation;
	
	// Use this for initialization
	void Start () {
		offset = transform.position - plane.transform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		transform.position = plane.transform.position + offset;
		yRotation = plane.transform.eulerAngles.y;
		transform.eulerAngles = new Vector3( 90, yRotation, 0 );

	}
}