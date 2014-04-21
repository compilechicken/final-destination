using UnityEngine;
using System.Collections;

public class LaserControl : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.transform.parent == null) {
			return;
		}
		Ship ship = other.transform.parent.GetComponent<Ship>();
		if (ship != null) {
			ship.AdjustHealth(-10);
			ship.Shake();
			Destroy(gameObject);
		}
	}
}
