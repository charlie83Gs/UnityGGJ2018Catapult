using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeAutoRotator : MonoBehaviour {
	public Transform target;
	[Range(0.01f,10.0f)]
	public float total_dist = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 targetDir = target.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards (transform.up, targetDir, 100.0f, 0.0f);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.Rotate (new Vector3(0.0f, -90.0f,90.0f));
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z);*/
		transform.LookAt (target);
		transform.Rotate (0.0f,0.0f,90.0f);
	}

	void FixedUpdate(){
		Vector3 targetDir = target.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, 100.0f, 0.0f).normalized;
		float distance = Vector3.Distance (transform.position,target.position);
		if (distance > total_dist) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, distance - total_dist);
		} else if (distance < total_dist) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, distance - total_dist);
		}
		//Debug.Log (distance);
	}
}
