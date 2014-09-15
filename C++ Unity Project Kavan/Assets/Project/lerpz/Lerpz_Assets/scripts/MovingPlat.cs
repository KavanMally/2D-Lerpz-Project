using UnityEngine;
using System.Collections;

public class MovingPlat : MonoBehaviour 
{
	public float amp = 5f;
	public float speed = 1f;
	private Vector3 direction = new Vector3(1, 0, 0);
	private Vector3 pos;

	void Start () 
	{
		pos = transform.position;
	}

	void Update()
	{
		Vector3 dir = transform.TransformDirection (direction);
		transform.position = pos + amp * dir * Mathf.Sin (6.28f * speed * Time.time);
	}
}
