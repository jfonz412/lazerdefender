using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	//destroy gameObject associated with what collided with our shredder
	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
	}
}
