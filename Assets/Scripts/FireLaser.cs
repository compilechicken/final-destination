using UnityEngine;
using System.Collections;
using InControl;

public class FireLaser : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shotPos;
	public float shotForce = 1000f;
	float time = 0;
	public float delay;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(InputManager.Devices[0].RightTrigger.IsPressed && time > delay)
		{
			Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
			shot.AddForce(shotPos.forward * shotForce);
			time = 0;
		}
		
	}

}
