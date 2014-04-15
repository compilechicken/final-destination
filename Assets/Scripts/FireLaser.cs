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
		bool shootStandardWeapon = false;
		time += Time.deltaTime;

		// Are controllers plugged in?
		if (InputManager.Devices.Count > 0) {
			shootStandardWeapon = InputManager.Devices[0].RightTrigger.IsPressed && time > delay;
		} else {
			// Debug mode, use keyboard controls.
			// Left click: shoot standard weapon
			shootStandardWeapon = Input.GetMouseButton(0) && time > delay;
		}

		if (shootStandardWeapon) {
			Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
			shot.AddForce(shotPos.forward * shotForce);
			time = 0;
			audio.Play ();
		}
	}

}
