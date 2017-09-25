using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public GameObject enemyLazer;
	public AudioClip lazerSound;
	public AudioClip enemyKilledSound;
	
	public float lazerSpeed; 
	public float health = 150;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;
	
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
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
		}
	}
	
	void Update(){
		float probability = shotsPerSecond * Time.deltaTime;
		if (Random.value < probability){
			FireLazer();
		}
	}
	
	void FireLazer(){
		GameObject lazer = Instantiate(enemyLazer, transform.position, Quaternion.identity) as GameObject;
		lazer.rigidbody2D.velocity = new Vector3(0,-lazerSpeed,0);
		AudioSource.PlayClipAtPoint(lazerSound, transform.position,1.0f);
	}
	
	void Die(){
		scoreKeeper.Score(scoreValue);
		AudioSource.PlayClipAtPoint(enemyKilledSound, transform.position,1.0f);
		Destroy(gameObject);
	}
}
