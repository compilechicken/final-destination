using UnityEngine;
using System.Collections;
using InControl;

public class ShipControls : MonoBehaviour {
	Ship ship;
	bool brake = false;
	bool boost = false;

	// Use this for initialization
	void Start () {
		ship = GetComponent<Ship>();
	}

	// Update is called once per frame
	void Update () {
		// If we don't have enough controllers, then use the keyboard
		if (ship.Player < InputManager.Devices.Count) {
			//Yaw
			if(InputManager.Devices[ship.Player].LeftStickX.IsNotNull)
			{
				transform.Rotate(0,InputManager.Devices[ship.Player].LeftStickX.Value,0);
			}
			//Pitch
			if(InputManager.Devices[ship.Player].LeftStickY.IsNotNull)
			{
				transform.Rotate(-1*InputManager.Devices[ship.Player].LeftStickY.Value,0,0);
			}
			//Roll
			if(InputManager.Devices[ship.Player].RightStickX.IsNotNull)
			{
				transform.Rotate(0,0,InputManager.Devices[ship.Player].RightStickX.Value);
			}

			boost = InputManager.Devices[ship.Player].LeftStickButton.IsPressed;
	
			brake = InputManager.Devices[ship.Player].Action2.IsPressed;

		} else {
			// Debug mode, use keyboard controls.
			// Yaw
			transform.Rotate(0, 100 * Input.GetAxis("mouse x") * Time.deltaTime, 0);

			//Pitch
			transform.Rotate(100 * Input.GetAxis("mouse y") * Time.deltaTime, 0, 0);

			//Roll
			if (Input.GetKey(KeyCode.Q)) {
				transform.Rotate(0, 0, -250 * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.E)) {
				transform.Rotate(0, 0, 250 * Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.Space))
			{
				boost = true;
			}
			if(Input.GetKey(KeyCode.LeftShift))
			{
				brake = true;
			}
			else
			{
				boost = false;
				brake = false;
			}
		}


		//Move forward constantly
		if(boost == true)
		{
			transform.position += -1 * transform.forward * 95f * Time.deltaTime;
		}
		else if(brake == true)
		{
			transform.position += -1 * transform.forward * 5f * Time.deltaTime;
		}
		else transform.position += -1 * transform.forward * 50f * Time.deltaTime;
	}
}
