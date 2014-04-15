using UnityEngine;
using System.Collections;

public class MissileControl : MonoBehaviour {
	public float acceleration;
	public float maxSpeed;

	public Transform target;

	// Use this for initialization
	void Start () {

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

		rigidbody.maxAngularVelocity = 90f;
	}

}
