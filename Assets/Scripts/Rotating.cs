﻿using UnityEngine;
using System.Collections;

public class Rotating : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Time.deltaTime, 0, 0);
	}
}
