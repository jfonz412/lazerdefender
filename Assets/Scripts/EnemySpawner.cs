using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10.0f;
	public float height = 5.0f;
	public float speed = 1.0f;
	
	private bool movingRight = true;
	private float xmax;
	private float xmin;

	// Use this for initialization
	void Start () {
		GetCameraSpace();
		SpawnEnemies();
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		MoveFormation();
		
		if(FormationDefeated()){
			Debug.Log("Formation Defeated");
			SpawnEnemies();
		}
	}
	
	void GetCameraSpace(){
		// not required for 2d game just for show
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		
		//get camera viewport bottom left and right edges
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceToCamera));
		
		//set the x min and max to the camera viewport's x min and max
		xmax = rightMost.x;
		xmin = leftMost.x;
	}
	
	void SpawnEnemies(){
		//for every Transform component in this gameObject, declared as 'child'
		// aka for every child object of 'this'
		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			//instantiate enemy as child of this child-transform (Position object)
			enemy.transform.parent = child;
		}
	}
	
	void MoveFormation(){
		if(movingRight){
			transform.position += Vector3.right * speed * Time.deltaTime; // so speed doesn't depend on framrate
		}else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		//multiply by half the width to get the edge rather than the center
		float rightEdgeOfFormation = transform.position.x + (width * 0.5f);
		float leftEdgeOfFormation = transform.position.x - (width * 0.5f);
		
		if(leftEdgeOfFormation < xmin){
			movingRight = true;
		}else if (rightEdgeOfFormation > xmax){
			movingRight = false;
		}
	}
	
	
	bool FormationDefeated(){
		//transforms are what keeps the child/parent relationship
		foreach(Transform childPostionGameObject in transform){
			if (childPostionGameObject.childCount > 0){
				return false;
			}
		}
		return true;
	}
}
