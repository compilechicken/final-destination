using UnityEngine;
using System.Collections;

public class PositionAtoB : MonoBehaviour {

	public Transform destination, start;
 
	void Start () {
		//DO NOT JUST CALL BALLCOROUTINE();
		StartCoroutine ( BallCoroutine() );
	}
	
	IEnumerator BallCoroutine () {
	

		while ( true ) {
			float time = 0f;
			Vector3 pointA = start.position;
			Vector3 pointB = destination.position;
			audio.Play ();
	
			while ( time < 11f ) {
				time += Time.deltaTime;	//increment time variable
				start.position = Vector3.Lerp ( pointB, pointA, time );
				yield return 1;	//wait a frame
			}
		}
	}
}
