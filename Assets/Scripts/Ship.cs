using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
	public int Player;

	//Health And Shields Variables
	public float MaxHealth;
	public float MaxShields = 50;
	float CurrentHealth;
	float CurrentShields;

	//OnGUI variables
	float HealthBarLength;
	float ShieldBarLength;
	public float HealthBarX;
	public float HealthBarY;
	public float ShieldBarX;
	public float ShieldBarY;
	public float BoostX;
	public float BoostY;
	//The Health and Shield bars will both use the HealthStyle and Texture
	//The texture is just white pixels that are tinted later using GUI.backgroundcolor = <Desired color>;
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
		CurrentShields = MaxShields;
		HealthStyle = new GUIStyle();
		HealthTexture = new Texture2D(1,1);
		HealthBarLength = Screen.width/2;
		HealthTexture.SetPixel(0,0, Color.white);
		HealthTexture.Apply();
		HealthStyle.normal.background = HealthTexture;
		HealthStyle.alignment = TextAnchor.MiddleCenter;


		//Call AdjustHealth once to initialize bar locations
		AdjustHealth(0);

		StartCoroutine(ShakeCoroutine());
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Laser")
		{
			Vector3 shake = 0.5f * (Quaternion.AngleAxis(Random.value * 360, Vector3.forward) * Vector3.right);
			ShakeTime shakeTime = new ShakeTime(shake, 1);
			shakes.AddLast(shakeTime);
			AdjustHealth (-10);
		}
	}




	// Update is called once per frame
	void Update () {
		// Triggers a redraw for the current health
		AdjustHealth(0);
	}

	// Triggers a camera shake
	public void Shake() {
		Vector3 shake = 0.5f * (Quaternion.AngleAxis(Random.value * 360, Vector3.forward) * Vector3.right);
		ShakeTime shakeTime = new ShakeTime(shake, 1);
		shakes.AddLast(shakeTime);
	}

	IEnumerator ShakeCoroutine() {

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

		//Draw the Shield Bar
		GUI.backgroundColor = Color.cyan;
		GUI.Box(new Rect(ShieldBarX, ShieldBarY, ShieldBarLength, 20),CurrentShields + "/" + MaxShields, HealthStyle);

	}
	public void AdjustHealth( float x)
	{
		//Prevent current health from being negative
		if(CurrentShields == 0)
		{
			CurrentHealth += x;
		}
		CurrentShields += x;
		//Prevent shields from going negative
		if(CurrentShields < 1)
		{
			CurrentShields = 0;
		}

		//Prevent health from going negative
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

		//Update health and shield bar lengths
		HealthBarLength = (Screen.width/2) * (CurrentHealth/MaxHealth);
		ShieldBarLength = (Screen.width/2) * (CurrentShields/MaxShields);

		//health bar x value, always centered
		HealthBarX = Screen.width/2 - HealthBarLength/2;
		ShieldBarX = Screen.width/2 - ShieldBarLength/2;

		//Health Bar height based on player
		//Player 1 bars
		if(Player == 1)
		{
			HealthBarY = 20;
			ShieldBarY = 50;
		}
		//Player 2 bars
		else 
		{
			HealthBarY = Screen.height/2 + 20;
			ShieldBarY = Screen.height/2 + 50;
		}
	}

































}
