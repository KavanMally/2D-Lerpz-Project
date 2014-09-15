using UnityEngine;
public class LerpzHealth : MonoBehaviour
{
	public int hp = 1, backup = 1;
	
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			Respawn res = gameObject.GetComponent<Respawn>();
			res.dead();
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			Damage(shot.damage);
			Destroy(shot.gameObject);
		}
		if (otherCollider.Equals(GameObject.Find("FallLimit").GetComponent<Collider2D>()))
			Damage(hp);
	}
}
