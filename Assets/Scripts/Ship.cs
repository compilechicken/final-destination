using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	public Transform model;
	Vector3 shake = Vector3.zero;
	float shakeTime;

	// Use this for initialization
	void Start () {
		shakeTime = 0;
		StartCoroutine(Shake());
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			shake.Normalize();
			Vector3 offset = Quaternion.AngleAxis(Random.value * 360, Vector3.forward) * Vector3.right;
			shake += offset * 2;
			shakeTime = 0;
		}
	}

	IEnumerator Shake() {
		while (true) {
			shakeTime += Time.deltaTime;
			if (shakeTime < 4) {
				model.localPosition = Mathf.Sin(shakeTime) * (2 - shakeTime) * shake;
			}
			yield return null;
		}
	}


}
