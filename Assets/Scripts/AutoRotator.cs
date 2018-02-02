using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoRotator : MonoBehaviour {

	private Vector3 rot;
	public Transform target;

	// Use this for initialization
	void Start () {
		//transform.LookAt(target);
		Vector3 targetDir = target.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards (transform.up, targetDir, 100.0f, 0.0f);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.Rotate (new Vector3(0.0f, -90.0f,90.0f));
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (new Vector3(5f,0.0f,0.0f));
	}

	public void manual_reset_rotation(){
		//transform.LookAt(target);
		Vector3 targetDir = (target.position - transform.position).normalized;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, 100.0f, 0.0f);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.Rotate (new Vector3(90.0f, 90.0f,90.0f));

	}
		
}
