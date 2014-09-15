using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	[HideInInspector]
	public bool Right = true;
	private Animator animator;
	private float horizontal = 0;
	private Transform groundCheck;
	[HideInInspector]
	public bool lerpzJump = false;
	public float jumpForce = 1000f;
	private bool grounded = false;
	private float maxSpeed = 1f;
	private float maxRun = 3f;
	private bool shoot = false;
	private bool floating = false;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
		groundCheck = transform.Find ("groundCheck");
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if (!grounded)
		{
			grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Floating"));
			if (grounded)
				floating = true;
			else
				floating = false;
		}
		horizontal = Input.GetAxis("Horizontal");
		if (horizontal != 0)
		{
			animator.SetInteger ("walk", 1);
			if (Input.GetKey (KeyCode.LeftShift))
					animator.SetInteger ("walk", 2);
		} else if (horizontal == 0)
			animator.SetInteger ("walk", 0);
		if (Input.GetButtonDown("Jump") && grounded)
		{
			animator.SetInteger ("jump", 1);
			lerpzJump = true;
		}
		else if (Input.GetKeyUp (KeyCode.Space) || grounded)
			animator.SetInteger ("jump", 0);
		if (!grounded)
			animator.SetInteger("jump", 1);

		if (Input.GetButtonDown ("Fire1"))
		{
			animator.SetBool ("shoot", true);
			shoot = true;
		}
		else if (Input.GetButtonUp("Fire1"))
		{
			animator.SetBool("shoot", false);
			shoot = false;
		}
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
				weapon.Attack(false);
		}
	}

	void FixedUpdate() 
	{
		if (horizontal > 0 && !Right)
			Flip();
		else if (horizontal < 0 && Right)
			Flip ();

		if (animator.GetInteger("walk") == 1)
		{
			if(horizontal * rigidbody2D.velocity.x < maxSpeed)
				rigidbody2D.AddForce(Vector2.right * horizontal * 300f);
		}
		else if (animator.GetInteger("walk") == 2)
		{
			if(horizontal * rigidbody2D.velocity.x < maxRun)
				rigidbody2D.AddForce(Vector2.right * horizontal * 400f);
		}
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		if(grounded){
			if (lerpzJump)
			{
				rigidbody2D.AddForce (new Vector2(0f, jumpForce));
				lerpzJump = false;
			}
		}

		if (horizontal == 0 && floating)
			GameObject.Find("Lerpz").transform.position = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Floating")).transform.position + new Vector3(0, .215f, 0);
	}

	void Flip()
	{
		Right = !Right;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
