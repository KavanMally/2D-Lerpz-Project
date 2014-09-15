using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	//public GameObject platform;
	public GameObject pointA;
	public GameObject pointB;

	public float travelSpeed;

	public bool isMoving;
	//public bool aboutPhase;

	private Vector3 platformPosition;
	private Vector3 pointAPosition;
	private Vector3 pointBPosition;



	// Use this for initialization
	void Start () {
		//platformPosition = platform.transform.position;
		//pointAPosition	 = pointA.transform.position;
		//pointBPosition	 = pointB.transform.position;

		Debug.Log ("Platform is moving");
	}
	
	// Update is called once per frame
	void Update () {

		//probably a more elegant way to check if it should be moving but oh well
		if (isMoving) { 

			//if(latformPosition!=
				transform.Translate(Vector3.right * travelSpeed * Time.deltaTime);

			
			
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		Debug.Log ("Platform should be turning around");
		travelSpeed *= -1;
	}



}

