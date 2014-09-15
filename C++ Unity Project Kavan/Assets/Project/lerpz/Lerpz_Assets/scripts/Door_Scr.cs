using UnityEngine;
using System.Collections;

public class Door_Scr : MonoBehaviour 
{
	private bool hit = false;
	private Transform Top, Bot, Lerpz;
	private float top, bottom, init;

	void Start() 
	{
		Lerpz = GameObject.Find("Lerpz").transform;
		Top = transform.Find("Door_Top");
		Bot = transform.Find("Door_Bot");
		init = Bot.position.y;
		top = transform.position.y;
		bottom = top*-1f + .14f;
	}

	void Update() 
	{
		//hit = Physics2D.Linecast (transform.position, lerpzCheck_L.position, 1 << LayerMask.NameToLayer("Player"));
		//if(!hit)
		//	hit = Physics2D.Linecast (transform.position, lerpzCheck_R.position, 1 << LayerMask.NameToLayer("Player"));
		if (Mathf.Abs(transform.position.x - Lerpz.position.x) < 1)
			hit = true;
		else
			hit = false;
		if (hit)
		{
			if (!(Bot.position.y <= bottom))
			{
				Bot.position -= new Vector3(0, .01f, 0);
				Top.position += new Vector3(0, .01f, 0);
			}
		}
		else
		{
			if (!(Bot.position.y >= init))
			{
				Bot.position += new Vector3(0, .01f, 0);
				Top.position -= new Vector3(0, .01f, 0);
			}
		}
	}
}
