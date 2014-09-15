using UnityEngine;
using System.Collections;

/*
 * README:
 * Set player tag to Player
 * 
 * 
 */

public class BlackHole : MonoBehaviour {


	public GameObject player;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Collider:" + collider.isTrigger);
		Debug.Log ("Death Field initialized");
		//player = GameObject.Find ("Playa");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Entered Kill Zone");
		Destroy ( player );
	}

	void OnTriggerStay2D(Collider2D other){
		//Debug.Log ("Hovering kill zone");
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("Exiting Kill Zone");
	}



}
