using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour
{
	public Transform shotPrefab;
	public float shootingRange = 1f;
	private float shootCooldown;
	private bool right = true;

	void Start ()
	{
		shootCooldown = 0f;
	}

	void Update ()
	{
		if (shootCooldown > 0)
			shootCooldown -= Time.deltaTime;
		if (gameObject.GetComponent<playerController>().Right)
			right = true;
		else
			right = false;
	}

	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRange;
			var shotTransform = Instantiate(shotPrefab) as Transform;
			if (right)
				shotTransform.position = new Vector3(transform.position.x + .15f, transform.position.y + .03f, 0f);
			else
				shotTransform.position = new Vector3(transform.position.x - .15f, transform.position.y + .03f, 0f);
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
				shot.isEnemyShot = isEnemy;
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				if (right)
					move.direction = this.transform.right;
				else
					move.direction = this.transform.right * -1;
			}
		}
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}