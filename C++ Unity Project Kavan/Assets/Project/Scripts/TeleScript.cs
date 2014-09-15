using UnityEngine;
using System.Collections;

public class TeleScript : MonoBehaviour {


	public GameObject playa;
	public bool willTransport;
	public GameObject partnerPort;
	public Vector3 partnerPortPos;
	public float TeleDelay;

	// Use this for initialization
	void Start () {
		partnerPortPos = partnerPort.transform.position;
	}

	void OnTriggerEnter2D(Collider2D c){
		Debug.Log ("Player should transport");
		if (willTransport) {
			playa.transform.position = partnerPortPos;
		//
			//Invoke("MovinPlaya", 
			//StartCoroutine("callPause");

		}
	}

	void MovinPlaya(){

		

	}
	/*
	IEnumerator callPause (float seconds) {

		Debug.Log("Before call to pause");
		yield return StartCoroutine(pause(seconds));
		Debug.Log("After call to pause");

	}
	*/
}
