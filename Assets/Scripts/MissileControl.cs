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
		// Zoom to target
		Vector3 toTarget = target.position - transform.position;
		rigidbody.AddForce(toTarget * acceleration * Time.deltaTime, ForceMode.Acceleration);
		transform.LookAt(target.position);

	}

}
