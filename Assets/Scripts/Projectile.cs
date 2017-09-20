using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float damage = 100f;
	
	//will be called by enemy on collision to recieve damage
	public float GetDamage(){
		return damage;
	}
	
	//will be called by enemy on collision to destroy lazer
	public void Hit(){
		Destroy(gameObject);
	}
}
