using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 10.0f;
	
	float padding = 0.5f;
	float xmin;
	float xmax;
	
	void Start(){
		//set camera distances
		//distance between player and the camera
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance)); //bottom left
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance)); //bottom right
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		MoveShip();
	}
	
	//transform does not need to be defined apprently
	void MoveShip(){
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;  //speed independent from framerate
		} 
		else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		//clamp player's x position
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
