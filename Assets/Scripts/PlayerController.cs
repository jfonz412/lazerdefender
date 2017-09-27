using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject basicLazer;
	public AudioClip lazerSound;
	public AudioClip damagedSound;
	public AudioClip playerKilledSound;
	
	public float health = 300f;
	public float speed = 10.0f;
	public float lazerSpeed;
	public float fireRate = 0.35f; //lazer per second of having space held down
	
	float padding = 0.5f;
	float xmin;
	float xmax;
	
	void Start(){
		ClampPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		MoveShip();
		if (Input.GetKeyDown(KeyCode.Space)){
			//middle argument is initial delay before first call, if zero you get a bug
			InvokeRepeating("FireLazer", 0.000001f, fireRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("FireLazer");
		}
	}
	
	void OnTriggerEnter2D(Collider2D col){
		// check if col has Projectile script/component
		Projectile lazer = col.gameObject.GetComponent<Projectile>();
		if (lazer){
			health -= lazer.GetDamage();
			if (health <= 0){
				Die();
			}
			lazer.Hit ();
			AudioSource.PlayClipAtPoint(playerKilledSound, transform.position,1.0f);
		}
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
	
	void ClampPlayer(){
		//This makes it so the ship will not leave the camera.
		//This function simply sets the camera's viewport as variables we can use to clamp the player
		//distance between player and the camera
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance)); //bottom left
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance)); //bottom right
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}
	
	void FireLazer(){
		Vector3 lazerPos = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
		GameObject lazer = Instantiate(basicLazer, lazerPos, Quaternion.identity) as GameObject;
		lazer.rigidbody2D.velocity = new Vector3(0,lazerSpeed,0);
		AudioSource.PlayClipAtPoint(lazerSound, transform.position,1.0f);
	}
	
	void Die(){
		// Get the LevelManager script from the LevelManager object
		LevelManager lvlManager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		AudioSource.PlayClipAtPoint(playerKilledSound, transform.position,10.0f);
		lvlManager.LoadLevel("Win Screen");
		Destroy(gameObject);
	}
}
