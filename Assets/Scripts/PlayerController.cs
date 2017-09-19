using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 10.0f;
	
	// Update is called once per frame
	void Update () {
		MoveShip();
	}
	
	//transform does not need to be defined apprently
	void MoveShip(){
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += new Vector3(-speed * Time.deltaTime, 0, 0); //speed independent from framerate
		} 
		else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
		}
	}
}
