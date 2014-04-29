using UnityEngine;
using System.Collections;
using InControl;

public class FireLaser : MonoBehaviour {
	public Rigidbody projectile;
	public Transform shotPos1;
	public Transform shotPos2;
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
			Rigidbody shot1 = Instantiate(projectile, shotPos1.position, shotPos1.rotation) as Rigidbody;
			shot1.AddForce(shotPos1.forward * shotForce);
			Rigidbody shot2 = Instantiate(projectile, shotPos2.position, shotPos2.rotation) as Rigidbody;
			shot2.AddForce(shotPos2.forward * shotForce);

			foreach (Collider modelCollider in GetComponent<Ship>().model.GetComponents<Collider>()) {
				Physics.IgnoreCollision(modelCollider, shot1.collider);
				Physics.IgnoreCollision(modelCollider, shot2.collider);
			}
			time = 0;
			audio.Play ();
		}
	}

}
