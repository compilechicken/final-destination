using UnityEngine;
using System.Collections;
using InControl;

public class FireLaser : MonoBehaviour {
	public GameObject Laserbeam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(InputManager.Devices[0].RightTrigger.IsNotNull)
		{
			Fire();
		}
	
	}
	void Fire()
	{
	}

}
