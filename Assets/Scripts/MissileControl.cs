using UnityEngine;
using System.Collections;

public class MissileControl : MonoBehaviour {
	public float acceleration;
	public float maxVelocity;

	public Transform target;

	// Use this for initialization
	void Start () {
		rigidbody.maxAngularVelocity = 1f;
	}

	// Update is called once per frame
	void Update () {
		// Turn to target
		Vector3 toTarget = target.transform.position - transform.position;
		toTarget.Normalize();

		Vector3 rotationAxis = Vector3.Cross(transform.forward, toTarget);
		// What is the angle to the target?
		float angle = rotationAxis.magnitude;
		angle = Mathf.Min(angle, 30);
		angle *= 50;
		rotationAxis.Normalize();
		rigidbody.AddTorque(rotationAxis * angle, ForceMode.Acceleration);

		rigidbody.AddForce(transform.forward * acceleration * Time.deltaTime, ForceMode.Acceleration);
		if (rigidbody.velocity.magnitude > maxVelocity) {
			rigidbody.velocity.Normalize();
			rigidbody.velocity *= maxVelocity;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.parent == null) {
			return;
		}
		Ship ship = other.transform.parent.GetComponent<Ship>();
		if (ship != null) {
			ship.AdjustHealth(-30);
			ship.Shake();
			Destroy(gameObject);
		}
	}

}
