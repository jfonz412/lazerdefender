using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
		//for every Transform component in this transform
		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			//instantiate enemy as child of this child transform (Position object)
			enemy.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
