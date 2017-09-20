using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {
	public float health = 150;

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
}
