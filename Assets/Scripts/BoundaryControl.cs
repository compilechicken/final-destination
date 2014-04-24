using UnityEngine;
using System.Collections;

public class BoundaryControl : MonoBehaviour {
	float distanceToDisplay = 500;
	Transform[] players = new Transform[2];
	string PLAYER_TAG = "Player";

	void Start() {
		GameObject[] players = GameObject.FindGameObjectsWithTag(PLAYER_TAG);
		for (int i = 0; i < 2; ++i) {
			this.players[i] = players[i].transform;
		}
	}

	void Update() {
		float closest = Mathf.Infinity;
		foreach (Transform player in players) {
			closest = Mathf.Min((player.position - transform.position).magnitude, closest);
		}

		renderer.enabled = closest < distanceToDisplay;
	}
}
