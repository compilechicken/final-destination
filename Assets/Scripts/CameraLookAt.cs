using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour {
	public Transform target;
	public float distance = 5f;
	public float height = 3f;
	public float damping = 5f;
	Vector3 wantedPosition;
	Quaternion wantedRotation;
	bool smoothRotation = true;
	public float rotationDamping = 10f;

	void Update() {

		wantedPosition = target.TransformPoint (0, height, distance);
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);

		if (smoothRotation)
		{
			wantedRotation = Quaternion.LookRotation((target.position + 5 * transform.up) - transform.position, target.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		} else {
			transform.LookAt(target, target.up);
		}
	}
}
