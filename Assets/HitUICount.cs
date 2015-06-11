using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HitUICount : MonoBehaviour {

	int objectsHit;
	int objectsLeft;
	Text counter;


	// Use this for initialization
	void Start () {
	
		objectsHit = 0;
		counter = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		objectsHit = GameObject.FindGameObjectsWithTag("Tank_Marked").Length;
		objectsLeft = GameObject.FindGameObjectsWithTag("Tank").Length;
		counter.text = "Tanks marked: " + objectsHit + ":" + objectsLeft;


	}
}
