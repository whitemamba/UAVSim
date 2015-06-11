using UnityEngine;
using System.Collections;

public class AutoPilot : MonoBehaviour {

	Vector3 coordEnd;
	float xEnd;
	float yEnd;
	Ray heightDetect;
	RaycastHit hit;
	public float speed = 30.0f;

	// Use this for initialization
	void Start () {
	
		Cursor.visible = false;
		if (gameObject.name=="PlaneWhole")
		{iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Path"), "time", 120, "easetype", iTween.EaseType.linear, "orienttopath", true, "lookTime", 0.2, "axis", "y"));}

		if (gameObject.name == "PlaneWhole 1") 
		{iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Path1"), "time", 120, "easetype", iTween.EaseType.linear, "orienttopath", true, "lookTime", 0.2, "axis", "y"));}

	
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position += transform.forward * Time.deltaTime * speed;
		//speed -= transform.forward.y * 40.0f * Time.deltaTime ;

		//if (speed <= 15.0f) {
		//	speed = 15.0f;
		//}
		
		//if (speed >= 50.0f) {
		//	speed = 50.0f;
		//}


		heightDetect = new Ray (transform.position, Vector3.down);

		if (Physics.Raycast (heightDetect, out hit, Mathf.Infinity)) {
			var targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 0.5f);



			Debug.DrawRay (heightDetect.origin, heightDetect.direction*1000);
	
		}

		transform.Translate(100 * Time.deltaTime, 0, 0);

	}


}
