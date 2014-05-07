using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public GameObject P1;
	public GameObject P2;
	public TextMesh top;
	public TextMesh bottom;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(P1.GetComponent<Ship>().CurrentHealth == 0 || P2.GetComponent<Ship>().CurrentHealth == 0)
		{
			P1.GetComponent<ShipControls>().enabled = false;
			P2.GetComponent<ShipControls>().enabled = false;
			top.text = "Game Over!";
			bottom.text = "Game Over!";
		}
	}
}
