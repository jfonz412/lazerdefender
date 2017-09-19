using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
	//draw sphere around position object in editor
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
