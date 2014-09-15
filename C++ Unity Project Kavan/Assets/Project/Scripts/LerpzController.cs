using UnityEngine;
using System.Collections;

public class LerpzController : MonoBehaviour {


	public bool isFalling;

	public float FallSpeed;
	public float MoveSpeed;

	// Use this for initialization
	void Start () {
	
		Physics.gravity = new Vector3(0, -1.0F, 0);
		
	}
	
	void FixedUpdate () {
	
		//gravity
		//if (isFalling)
			//transform.Translate(Vector3.down * FallSpeed * Time.deltaTime);

		//jump
		//if(Input.GetKey(KeyCode.Space))
			//insert jump coder here
			//transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
		
		/* JUNK
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);

		*/

		//standard left/right shift
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A))
			//transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
						rigidbody.AddForce (Vector3.left * MoveSpeed);
		
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			//transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
			rigidbody.AddForce (Vector3.right * MoveSpeed);
	}

	void OnCollisionEnter(Collision c){
		isFalling = false;
	}

	void OnCollisionExit(Collision c){
		isFalling = true;
	}

	void OnCollisionStay(Collision c){
		
	}

}
