using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zrotator : MonoBehaviour {
	[Range(-50f,50f)]
	public float zspeed = 10.0f;
	[Range(-50f,50f)]
	public float xspeed = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.right *Time.deltaTime*zspeed);
		this.transform.Rotate (Vector3.down *Time.deltaTime*zspeed);
	}
}
