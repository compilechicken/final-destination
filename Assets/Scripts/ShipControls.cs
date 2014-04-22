using UnityEngine;
using System.Collections;
using InControl;

public class ShipControls : MonoBehaviour {
	// Use this for initialization
	public bool Boost = false;
	public float BoostAmt = 100f;
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		// Are controllers plugged in?
		if (gameObject.GetComponent<Ship>().Player == 2 && InputManager.Devices.Count > 0) {
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
			//Boost
			if(InputManager.Devices[0].RightStickButton.IsPressed)
			{
				Boost = true;
				BoostAmt -= 2;
				if(BoostAmt < 0)
					BoostAmt = 0;
			}
			else 
			{
				Boost = false; 
				BoostAmt++;
				if(BoostAmt > 100)
					BoostAmt = 100;
			}
			//End Boost

		} else {
			// Debug mode, use keyboard controls.
			// Yaw
			transform.Rotate(0, 100 * Input.GetAxis("mouse x") * Time.deltaTime, 0);

			//Pitch
			transform.Rotate(100 * Input.GetAxis("mouse y") * Time.deltaTime, 0, 0);

			//Roll
			if (Input.GetKey(KeyCode.Q)) {
				transform.Rotate(0, 0, -75 * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.E)) {
				transform.Rotate(0, 0, 75 * Time.deltaTime);
			}
			if(Input.GetKey (KeyCode.Space))
			{
				Boost = true;
				BoostAmt -= 2;
				if(BoostAmt < 0)
					BoostAmt = 0;
			}
			else 
			{
				Boost = false; 
				BoostAmt++;
				if(BoostAmt > 100)
					BoostAmt = 100;
			}

		}


		//Move forward constantly
		if(Boost == true)
		{
			transform.position += -1 * transform.forward * 75f * Time.deltaTime;
		}
		else transform.position += -1 * transform.forward * 50f * Time.deltaTime;
	}
}
