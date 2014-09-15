using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	private bool hit;
	private Transform lerpzCheck;

	void Start ()
	{
		lerpzCheck = transform.Find("lerpzCheck");
	}

	void Update ()
	{
		hit = Physics2D.Linecast (transform.position, lerpzCheck.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void FixedUpdate()
	{
		if (!hit)
			rigidbody2D.AddForce(Vector2.right * 50f);
	}
}
