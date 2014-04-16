using UnityEngine;
using System.Collections;
using InControl;

public class FireMissile : MonoBehaviour {
	public Transform target;
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
		bool shoot = false;
		time += Time.deltaTime;

		// Are controllers plugged in?
		if (InputManager.Devices.Count > 0) {
			shoot = InputManager.Devices[0].LeftTrigger.IsPressed && time > delay;
		} else {
			// Debug mode, use keyboard controls.
			// Left click: shoot standard weapon
			shoot = Input.GetMouseButton(1) && time > delay;
		}

		if (shoot) {
			GameObject missile = Instantiate(projectile, shotPos.position, shotPos.rotation) as GameObject;
			MissileControl missileControl = missile.GetComponent<MissileControl>();
			missileControl.target = target;
			missileControl.enabled = true;
			time = 0;
		}
	}

}
