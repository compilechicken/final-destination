using UnityEngine;
using System.Collections;

public class ProjectileCollision : MonoBehaviour {

	public float damage;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.tag == "Player")
		{
			c.gameObject.GetComponent<Ship>().AdjustHealth (damage);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
