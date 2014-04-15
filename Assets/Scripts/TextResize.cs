using UnityEngine;
using System.Collections;

public class TextResize : MonoBehaviour {

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
	
			while ( time < 1f ) {
				time += Time.deltaTime;	//increment time variable
				start.position = Vector3.Lerp ( pointA, pointB, time );
				//start.position = Vector3.Lerp ( pointB, pointA, time );
				destination.position = Vector3.Lerp ( pointB, pointA, time );
				yield return 1;	//wait a frame
			}
		}
	}
}
