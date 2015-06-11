using UnityEngine;
using System.Collections;

public class PlanePilot : MonoBehaviour {
	public float speed = 30.0f;
	public GameObject explosion;
	bool isDead = false;
	// Use this for initialization
	void Start () {

		Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {

	

		transform.position += transform.forward * Time.deltaTime * speed;
		speed -= transform.forward.y * 40.0f * Time.deltaTime ;
		if (speed <= 15.0f) {
			speed = 15.0f;
		}

		if (speed >= 50.0f) {
			speed = 50.0f;
		}
		transform.Rotate (Input.GetAxis ("Vertical"), 0.0f, -Input.GetAxis ("Horizontal")) ;
		float TerrainHeightLocation = Terrain.activeTerrain.SampleHeight (transform.position);

		if ( (TerrainHeightLocation > transform.position.y) ) { //the plane crashed
			

	

			transform.position = new Vector3 (transform.position.x,
			                                  TerrainHeightLocation,
			                                  transform.position.z);
			Instantiate(explosion, transform.position, transform.rotation);
			gameObject.transform.root.gameObject.SetActive(false);
			
			Debug.Log ("Waiting");
			Invoke ("MyRestart", 4); // waits x seconds
			
			Debug.Log ("Waited for x seconds");

			Debug.Log ("Reloaded level");
			
			
		}
	}

	void LateUpdate(){
		Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
		float bias = 0.90f;
		Camera.main.transform.position = Camera.main.transform.position * bias + 
			moveCamTo * (1.0f - bias);
		Camera.main.transform.LookAt (transform.position + transform.forward * 5000.0f);
		
	}
	
	public void MyRestart(){
		
		Application.LoadLevel(Application.loadedLevel);

		// Put your codes where ever in this method.
	}
	

	
}