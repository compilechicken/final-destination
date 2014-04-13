using UnityEngine;
using System.Collections;
using InControl;

public class ShipControls : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		// Are controllers plugged in?
		if (InputManager.Devices.Count > 0) {
			//Yaw
			if(InputManager.Devices[0].LeftStickX.IsNotNull)
			{
				transform.Rotate(0,InputManager.Devices[0].LeftStickX.Value,0);
			}
			//Pitch
			if(InputManager.Devices[0].LeftStickY.IsNotNull)
			{
				transform.Rotate(-1*InputManager.Devices[0].LeftStickY.Value,0,0);
			}
			//Roll
			if(InputManager.Devices[0].RightStickX.IsNotNull)
			{
				transform.Rotate(0,0,InputManager.Devices[0].RightStickX.Value);
			}
		} else {
			// Debug mode, use keyboard controls.
			// TODO: Add controls!
		}


		//Move forward constantly
		transform.position += -1 * transform.forward * 5f * Time.deltaTime;
	}
}
