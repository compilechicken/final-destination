using UnityEngine;
using System.Collections;

public class BoundaryControl : MonoBehaviour {
	float distanceToDisplay = 400;
	Transform[] players = new Transform[2];
	string PLAYER_TAG = "Player";
	int BOUNDARY_LAYER = 1 << 8;

	void Start() {
		GameObject[] players = GameObject.FindGameObjectsWithTag(PLAYER_TAG);
		for (int i = 0; i < 2; ++i) {
			this.players[i] = players[i].transform;
		}
	}

	void Update() {
		bool doRender = false;
		foreach (Transform player in players) {
			doRender |= Physics.Raycast(player.position, -transform.up, distanceToDisplay, BOUNDARY_LAYER);
		}

		renderer.enabled = doRender;
	}
}
