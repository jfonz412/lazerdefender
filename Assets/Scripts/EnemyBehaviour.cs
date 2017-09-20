using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject enemyLazer;
	public float lazerSpeed; 
	public float health = 150;
	public float shotsPerSecond = 0.5f;

	void OnTriggerEnter2D(Collider2D col){
		// check if col has Projectile script/component
		Projectile lazer = col.gameObject.GetComponent<Projectile>();
		if (lazer){
			health -= lazer.GetDamage();
			if (health <= 0){
				Destroy(gameObject);
			}
			lazer.Hit ();
			Debug.Log ("Hit by projectile");
		}
	}
	
	void Update(){
		float probability = shotsPerSecond * Time.deltaTime;
		if (Random.value < probability){
			FireLazer();
		}
	}
	
	void FireLazer(){
		Vector3 lazerPos = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
		GameObject lazer = Instantiate(enemyLazer, lazerPos, Quaternion.identity) as GameObject;
		lazer.rigidbody2D.velocity = new Vector3(0,-lazerSpeed,0);
	}
}
