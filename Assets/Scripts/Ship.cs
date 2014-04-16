using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
	public int Player;

	//Health And Shields Variables
	public float MaxHealth;
	//public float MaxShields;
	float CurrentHealth;
	//float CurrentShields;

	//OnGUI variables
	float HealthBarLength;
	public float HealthBarX;
	public float HealthBarY;
	GUIStyle HealthStyle;
	Texture2D HealthTexture;


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
		//OnGUI Initializations
		CurrentHealth = MaxHealth;
		//CurrentShields = MaxShields;
		HealthStyle = new GUIStyle();
		HealthTexture = new Texture2D(1,1);
		HealthBarLength = Screen.width/2;
		HealthTexture.SetPixel(0,0, Color.white);
		HealthTexture.Apply();
		HealthStyle.normal.background = HealthTexture;
		HealthStyle.alignment = TextAnchor.MiddleCenter;



		StartCoroutine(Shake());
	}

	// Update is called once per frame
	void Update () {
		AdjustHealth(0);
		if (Input.GetKeyDown(KeyCode.Space)) {
			Vector3 shake = 0.5f * (Quaternion.AngleAxis(Random.value * 360, Vector3.forward) * Vector3.right);
			ShakeTime shakeTime = new ShakeTime(shake, 1);
			shakes.AddLast(shakeTime);
			AdjustHealth (-10);
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
	void OnGUI()
	{
		//Draw the Health Bar
		GUI.backgroundColor = Color.red;
		GUI.Box(new Rect(HealthBarX, HealthBarY, HealthBarLength, 20),CurrentHealth + "/" + MaxHealth, HealthStyle);
	}
	void AdjustHealth( float x)
	{
		//Prevent current health from being negative
		CurrentHealth += x;
		if(CurrentHealth < 1)
		{
			CurrentHealth = 0;
		}

		//Prevent current health from going over the max health
		if(CurrentHealth > MaxHealth)
		{
			CurrentHealth = MaxHealth;
		}

		//Prevent a divide-by-zero error
		if(MaxHealth < 1)
		{
			MaxHealth = 1;
		}

		//Update health bar length
		HealthBarLength = (Screen.width/2) * (CurrentHealth/MaxHealth);

		//Health Bar Location based on player
		if(Player == 1)
		{
			HealthBarY = 20;
		}
		else HealthBarY = Screen.height/2 + 20;
	}
	/*
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Laser")
		{
			health -= <laser value>;
		}

		if(col.gameObject.tag == "Missile")
		{
			health -= <missile value>;
		}

		//Beam will be a raycast check
	}
	*/
































}
