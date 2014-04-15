using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {

	// Represents a Shake event along the specified vector, with a
	// remaining duration specified in seconds.
	private struct ShakeTime {
		public Vector3 vector;
		public float time;

		public ShakeTime(Vector3 vector, float time) {
			this.vector = vector;
			this.time = time;
		}
	}

	public Transform model;

	// The list of shake objects that we need to consider
	LinkedList<ShakeTime> shakes = new LinkedList<ShakeTime>();

	// Use this for initialization
	void Start () {
		StartCoroutine(Shake());
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Vector3 shake = 0.5f * (Quaternion.AngleAxis(Random.value * 360, Vector3.forward) * Vector3.right);
			ShakeTime shakeTime = new ShakeTime(shake, 1);
			shakes.AddLast(shakeTime);
		}
	}

	IEnumerator Shake() {
		while (true) {
			model.localPosition = Vector3.zero;

			// Step through the linked list to figure out what the net
			// displacement of the ship should be
			LinkedListNode<ShakeTime> shakeTime = shakes.First;
			while (shakeTime != shakes.Last) {
				// Cache the next node so we can move to it
				LinkedListNode<ShakeTime> nextNode = shakeTime.Next;
				// Current shake's contribution
				model.localPosition += (shakeTime.Value.time) * Mathf.Sin(shakeTime.Value.time * 20) * shakeTime.Value.vector;

				if (shakeTime.Value.time <= 0) {
					// Duration for this shake is complete, delete it
					shakes.Remove(shakeTime);
				} else {
					// Update time remaining in shake
					ShakeTime updated = new ShakeTime(shakeTime.Value.vector, shakeTime.Value.time - Time.deltaTime);
					shakeTime.Value = updated;
				}
				shakeTime = nextNode;
			}
			yield return null;
		}
	}


}
