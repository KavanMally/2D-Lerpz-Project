using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public void dead()
	{
		LerpzHealth health = gameObject.GetComponent<LerpzHealth> ();
		health.hp = health.backup;
		gameObject.transform.position = GameObject.Find ("Spawner").transform.position + new Vector3 (0, .5f, 0);
	}
}
