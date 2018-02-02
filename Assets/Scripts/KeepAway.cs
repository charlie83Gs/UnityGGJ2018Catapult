using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAway : MonoBehaviour {


	public float total_dist = 3.0f;
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Vector3 targetDir = target.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, 100.0f, 0.0f).normalized;
		float distance = Vector3.Distance (transform.position,target.position);
		if (distance < total_dist) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, distance - total_dist);
		}
		//Debug.Log (distance);
	}
}
