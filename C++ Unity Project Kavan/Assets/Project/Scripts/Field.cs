using UnityEngine;
using System.Collections;

/*
 * README
 * Set player tag to "Player"
 * 
 *
 */
public class Field : MonoBehaviour {


	public float timeRate = 1;    //somehow multiplying time by it makes pull "stronger", will investigate when i feel like it
	//public float dragSpeed = 10f; //useless now
	public Vector3 DirectionToDeath; //reference to destination of field
	public bool moveHo = false; //condition when to move
	public GameObject playa; //referenced to move him
	public GameObject hole; //referenced to get its pos
	public Vector3 currPos; //referenced for lerp method
	public GameObject killa;

	// Use this for initialization
	void Start () {
		Debug.Log ("Field Startup");
		//hole = GameObject.Find ("InnerDeath");  //get object, currently all dups of it only use this on 1 hole, not hole its assigned to 
		//hole = GameObject.Find ("BlackHole/InnerDeath");


		//playa = GameObject.Find ("Playa");

		DirectionToDeath = new Vector3 (hole.transform.position.x/Mathf.Abs(hole.transform.position.x),
		                                	hole.transform.position.y/Mathf.Abs(hole.transform.position.y),
		                                		0);
	}

	/*************************************************************
	 * 
	 * WARNING!	
	 * This is where the complex transform stuff come in to drag player into hole
	 * Comprehend at your own risk!
	 *********************************************************/


	// Update is called once per frame
	//not fixedupdate so player has chance to escape
	void Update () {
		if (moveHo) { 
			//playa.transform.Translate (Vector3.right * dragSpeed * Time.deltaTime);
			//dummy statement that makes it "work"


			DirectionToDeath = new Vector3 (hole.transform.position.x,hole.transform.position.y,hole.transform.position.z);
			currPos = new Vector3(playa.transform.position.x,playa.transform.position.y,0);

			playa.transform.position=Vector3.Lerp(currPos,DirectionToDeath,Time.deltaTime * timeRate);
			//somehow time rate (even at 1) causes pull to be stronger
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		Debug.Log ("Entered field zone");
		moveHo = true;


	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("Exiting field zone");
		moveHo = false;
	}

	void OnTriggerStay2d(Collider other){
		Debug.Log ("I should me moving");
	}
}
