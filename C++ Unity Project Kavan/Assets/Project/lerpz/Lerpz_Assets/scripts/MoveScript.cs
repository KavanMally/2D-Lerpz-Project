using UnityEngine;
public class MoveScript : MonoBehaviour
{
	public Vector2 speed = new Vector2(10, 10);
	public Vector3 direction = new Vector3(-1, 0, 0);
	
	private Vector2 movement;

	void Start()
	{
		//gameObject.transform.localPosition.x = GameObject.Find("lerpz").transform.localPosition.x + .1f;
		//gameObject.transform.localPosition.y = GameObject.Find("lerpz").transform.localPosition.x + .1f;
		//this.GetComponent<Transform>().localPosition = new Vector3 (GameObject.Find ("lerpz").transform.localPosition.x + .1f, GameObject.Find ("lerpz").transform.localPosition.x + .1f, 0);
	}
	
	void Update()
	{
		movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
}

