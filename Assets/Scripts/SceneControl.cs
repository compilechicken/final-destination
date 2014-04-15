using UnityEngine;
using System.Collections;

public class SceneControl : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {
			Application.LoadLevel (0);
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			Application.LoadLevel (1);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			Application.LoadLevel (2);
		}
	}
}
